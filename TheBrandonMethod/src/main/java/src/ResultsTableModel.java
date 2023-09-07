package src;

import javax.swing.table.AbstractTableModel;

public class ResultsTableModel extends AbstractTableModel {
    private int lineNumber;
    final private String[] columnNames = {
            "X",
            "Y Эксп",
            "Y1",
            "Y2",
            "Y3",
            "Y4",
            "Y5",
            "Y6"
    };

    Object[][] data;

    ResultsTableModel(int lineNumber) {
        super();
        this.lineNumber = lineNumber;
        data = new Object[this.lineNumber][columnNames.length];
        for (int i = 0; i < this.lineNumber; i++) {
            for (int j = 0; j < columnNames.length; j++) {
                data[i][j] = " ";
            }
        }
    }

    @Override
    public boolean isCellEditable(int row, int column) {
        return column != 0;
    }

    public int getColumnCount() {
        return columnNames.length;
    }

    public int getRowCount() {
        return data.length;
    }

    public String getColumnName(int col) {
        return columnNames[col];
    }

    public Object getValueAt(int row, int col) {
        return data[row][col].toString();
    }

    public void insertIntoRow(int rowId, Object[] rowData) {
        for (int i = 0; i < this.getRowCount(); i++) {
            data[i][rowId] = rowData[i];
        }
    }

    @Override
    public void setValueAt(Object aValue, int rowIndex, int columnIndex) {
        if (this.isCellEditable(rowIndex, columnIndex)) {
            this.data[rowIndex][columnIndex] = aValue;
        }
    }
}
