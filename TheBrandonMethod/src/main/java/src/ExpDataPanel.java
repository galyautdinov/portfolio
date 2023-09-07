package src;

import javax.swing.*;
import java.awt.*;

class ExpDataPanel extends Panel {
    JTable dataTable;

    ExpDataTableModel myTableModel;


    ExpDataPanel(int lineNumber) {
        super();
        setLayout(new GridLayout());

        myTableModel = new ExpDataTableModel(lineNumber);
        dataTable = new JTable(myTableModel);
        dataTable.setRowHeight(23);
        add(dataTable);
        JScrollPane scrollPane = new JScrollPane(dataTable);
        scrollPane.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
        scrollPane.setBounds(5, 10, 300, 150);
        scrollPane.setVisible(true);
        add(scrollPane);
    }
}