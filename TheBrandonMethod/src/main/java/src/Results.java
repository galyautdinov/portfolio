package src;

public class Results {
    float yAverage;

    RegResult ResultFunction;

    Calculation[][] functions;

    int[] optimalFuncIndex;

    Float[][] yXn;

    int lineNumber;

    Results(int lineNumber) {
        optimalFuncIndex = new int[3];
        functions = new Calculation[3][6];
        this.lineNumber = lineNumber;
        yXn = new Float[3][lineNumber];
    }
}
