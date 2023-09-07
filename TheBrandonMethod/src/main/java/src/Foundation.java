package src;

public class Foundation {
    private final int m = 3;
    private final int lineNumber;
    private Float[][] x;
    private Float[] y;
    private float[][] matrixD = new float[4][4];
    private float yAverage = 0;
    private Float[] yNormalized;
    private float[] rYx = new float[3];
    private final int[] ryxOrder = {0, 1, 2};
    private Calculation[] resultFunctions = new Calculation[3];

    Results results;

    Foundation(int lineNumber) {
        this.lineNumber = lineNumber;
        yNormalized = new Float[lineNumber];
    }

    public Results calculate(Float[][] x, Float[] y) {
        this.x = x;
        this.y = y;

        results = new Results(lineNumber);

        getYAverage();
        normalyzeY();
        fillMatrixD();
        fillRyx();
        sortRyx();
        functionBuild();
        //printResultTable();
        results.ResultFunction = new RegResult(yAverage, resultFunctions[0], resultFunctions[1], resultFunctions[2]);
        return results;
    }

    private void getYAverage() {
        for (int i = 0; i < lineNumber; i++) {
            this.yAverage += this.y[i];
        }
        this.yAverage = this.yAverage / this.lineNumber;
    }

    private void normalyzeY() {
        for (int i = 0; i < lineNumber; i++)
            this.yNormalized[i] = this.y[i] / this.yAverage;
    }

    private float ryxK(Float[] x, Float[] y) { //22, 22
        float sumX = 0;
        float sumY = 0;
        float sumXY = 0;
        float sumXSq = 0;
        float sumYSq = 0;

        for (int i = 0; i < lineNumber; i++) {
            sumX += x[i];
            sumY += y[i];
            sumXY += x[i] * y[i];
            sumXSq += x[i] * x[i];
            sumYSq += y[i] * y[i];
        }
        return (lineNumber * sumXY - sumX * sumY) / (float) Math.sqrt((lineNumber * sumXSq - sumX * sumX) * (lineNumber * sumYSq - sumY * sumY));
    }

    // заполнение матрицы matrix_D
    private void fillMatrixD() {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j <= i; j++) {
                if (i == j)
                    this.matrixD[i][j] = 1;
                else if (i == 3)
                    this.matrixD[i][j] = ryxK(y, x[j]);
                else
                    this.matrixD[i][j] = ryxK(x[i], x[j]);

                this.matrixD[j][i] = matrixD[i][j];
            }

        }
    }

    // Считает детерминант
    private float det(int a, int b) { // строка. столбец
        int ind = 0;
        float[] els = new float[9];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if ((i != a) & (j != b)) {
                    els[ind] = this.matrixD[i][j];
                    ind++;
                }
            }
        }
        return els[0] * els[4] * els[8] + els[1] * els[5] * els[6] + els[3] * els[7] * els[2];
    }

    private void fillRyx() {
        for (int k = 0; k < this.m; k++) {
            this.rYx[k] = (float) (Math.abs(det(m, k) / Math.sqrt(det(m, m) * det(k, k))));
        }
    }

    private void sortRyx() {  // сортировка пузырьком; в order_corellation_coof_ryx сохраняется порядок
        float fbuf;
        int ibuf;
        for (int i = 1; i < 3; i++) {
            for (int j = i; j < 3; j++) {
                if (this.rYx[j - 1] < this.rYx[j]) {
                    fbuf = this.rYx[j - 1];
                    this.rYx[j - 1] = this.rYx[j];
                    this.rYx[j] = fbuf;

                    ibuf = this.ryxOrder[j - 1];
                    this.ryxOrder[j - 1] = this.ryxOrder[j];
                    this.ryxOrder[j] = ibuf;
                }
            }
        }
    }

    private void functionBuild() {
        for (int i = 0; i < 3; i++) {
            Calculation result = functionSelection(this.x[this.ryxOrder[i]], this.yNormalized, i); //подбор оптимальной зависимости для x[i]
            this.resultFunctions[i] = result;

            for (int j = 0; j < lineNumber; j++) {
                this.yNormalized[j] = this.yNormalized[j] / result.calculate(x[this.ryxOrder[i]][j]); //избавляемся от влияния x[i]
            }
        }

    }

    private Calculation functionSelection(Float[] x, Float[] y, int functionIndex) { //selects the best function
        float[] A = new float[6];
        float[] B = new float[6];
        float[] a = new float[6];
        float[] b = new float[6];
        System.arraycopy(y, 0, this.results.yXn[functionIndex], 0, y.length);

        float[] deviationSum = new float[6];

        Float[] yPowMinOne = new Float[lineNumber];
        Float[] xPowMinOne = new Float[lineNumber];
        Float[] lnX = new Float[lineNumber];
        Float[] lnY = new Float[lineNumber];


        for (int i = 0; i < lineNumber; i++) {
            yPowMinOne[i] = 1 / y[i];
            xPowMinOne[i] = 1 / x[i];
            lnX[i] = (float) Math.log(x[i]);
            lnY[i] = (float) Math.log(y[i]);
        }

        float[] res;

        //type 1
        res = mnkLinear(x, y);
        A[0] = res[0];
        B[0] = res[1];
        //type 2
        res = mnkLinear(x, yPowMinOne);
        A[1] = res[0];
        B[1] = res[1];
        //type 3
        res = mnkLinear(xPowMinOne, y);
        A[2] = res[0];
        B[2] = res[1];
        //type 4
        res = mnkLinear(lnX, lnY);
        A[3] = res[0];
        B[3] = (float) Math.exp(res[1]);
        //type 5
        res = mnkLinear(x, lnY);
        A[4] = res[0];
        B[4] = (float) Math.exp(res[1]);
        //type 6
        res = mnkLinear(lnX, y);
        A[5] = res[0];
        B[5] = res[1];

        //обратное преобразование коофицентов
        //type 1
        a[0] = A[0];
        b[0] = B[0];
        //type 2
        a[1] = A[1];
        b[1] = B[1];
        //type 3
        a[2] = A[2];
        b[2] = B[2];
        //type 4
        a[3] = A[3];
        b[3] = (float) Math.exp(B[3]);
        //type 5
        a[4] = A[4];
        b[4] = (float) Math.exp(B[4]);
        //type 6
        a[5] = A[5];
        b[5] = B[5];

        for (int i = 0; i < lineNumber; i++) {
            deviationSum[0] += Math.pow((y[i] - (a[0] * x[i] + b[0])), 2);
            deviationSum[1] += Math.pow((y[i] - 1 / (a[1] * x[i] + b[1])), 2);
            deviationSum[2] += Math.pow((y[i] - (a[2] / x[i] + b[2])), 2);
            deviationSum[3] += Math.pow((y[i] - (Math.pow(x[i], a[3]) * b[3])), 2);
            deviationSum[4] += Math.pow((y[i] - (Math.exp(a[4] * x[i]) * b[4])), 2);
            deviationSum[5] += Math.pow((y[i] - (a[5] * Math.log(x[i]) + b[5])), 2);
        }

        float mn = deviationSum[0];
        int functionType = 7;

        for (int i = 0; i < 6; i++) {
            if (deviationSum[i] <= mn) {
                functionType = i;
                mn = deviationSum[i];
            }
        }
        results.optimalFuncIndex[functionIndex] = functionType;
        for (int i = 0; i < 6; i++) {
            results.functions[functionIndex][i] = new Calculation(a[i], b[i], i);
        }

        return new Calculation(a[functionType], b[functionType], functionType);
    }

    private float[] mnkLinear(Float[] x, Float[] y) { // returns a and b
        float sumX = 0;
        float sumY = 0;
        float sumXY = 0;
        float sumXSq = 0;

        for (int i = 0; i < 8; i++) {
            sumX += x[i];
            sumY += y[i];
            sumXY += x[i] * y[i];
            sumXSq += x[i] * x[i];
        }

        float[] res = new float[2];
        res[0] = (lineNumber * sumXY - sumX * sumY) / (lineNumber * sumXSq - sumX * sumX);
        res[1] = (sumXSq * sumY - sumX * sumXY) / (lineNumber * sumXSq - sumX * sumX);

        return res;//[a, b]
    }

    private void printResultTable() {
        for (int i = 0; i < lineNumber; i++) {
            float yRegression = (yAverage * resultFunctions[0].calculate(x[ryxOrder[0]][i]) *
                    resultFunctions[1].calculate(x[ryxOrder[1]][i]) *
                    resultFunctions[2].calculate(x[ryxOrder[2]][i]));

        }
    }
}
