package src;

public class RegResult {
    private final Calculation func1;
    private final Calculation func2;
    private final Calculation func3;
    private final float yAverage;
    
    public RegResult(float yAverage, Calculation func1, Calculation func2, Calculation func3) {
        this.yAverage = yAverage;
        this.func1 = func1;
        this.func2 = func2;
        this.func3 = func3;
    }

    public float calculate(float x1, float x2, float x3) {
        return this.yAverage * func1.calculate(x1) * func2.calculate(x2) * func3.calculate(x3);
    }

    public String toString() {
        return this.yAverage + "*" + func1.toString() + "*\n" + func2.toString() + "*" + func3.toString();
    }

    public Calculation getFunc1() {
        return func1;
    }

    public Calculation getFunc2() {
        return func2;
    }

    public Calculation getFunc3() {
        return func3;
    }
}
