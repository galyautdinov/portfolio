package src;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.chart.plot.XYPlot;
import org.jfree.chart.renderer.xy.XYLineAndShapeRenderer;
import org.jfree.data.xy.XYSeriesCollection;

import javax.swing.*;
import java.awt.*;

class Tabs extends JTabbedPane {

    ChartPanel resultPLot;
    ChartPanel firstParameterPLot;
    ChartPanel secondParameterPLot;
    ChartPanel thirdParameterPLot;
    ExpDataPanel showDataPanel;

    ResultsPanel x1Results;
    ResultsPanel x2Results;
    ResultsPanel x3Results;

    JFreeChart chartX1;
    JFreeChart chartX2;
    JFreeChart chartX3;
    JFreeChart chartResult;
    XYSeriesCollection x1Dataset;
    XYSeriesCollection x2Dataset;
    XYSeriesCollection x3Dataset;
    XYSeriesCollection resultDataset;

    XYLineAndShapeRenderer resultPlotRenderer;
    XYPlot resultPlotGotPlot;

    Tabs(int lineNumber) {
        super(JTabbedPane.TOP, JTabbedPane.SCROLL_TAB_LAYOUT);
        showDataPanel = new ExpDataPanel(lineNumber);
        //first chart
        x1Dataset = new XYSeriesCollection();
        chartX1 = ChartFactory.createXYLineChart("Функция Y(X1)",
                "X1", "Функция Y(X1)", x1Dataset, PlotOrientation.VERTICAL, true, false, false);
        firstParameterPLot = new ChartPanel(chartX1);
        chartX1.setBackgroundPaint(new GradientPaint(0, 0, Color.white, 1000, 1000, new Color(180, 255, 180)));
        chartX1.getPlot().setBackgroundPaint( new Color(220, 220, 220));
        chartX1.getXYPlot().setDomainGridlinePaint(new Color(50, 50, 50));
        chartX1.getXYPlot().setRangeGridlinePaint(new Color(50, 50, 50));

        x2Dataset = new XYSeriesCollection();
        chartX2 = ChartFactory.createXYLineChart("Функция Y(X2)",
                "X2", "Функция Y(X2)", x2Dataset, PlotOrientation.VERTICAL, true, false, false);
        secondParameterPLot = new ChartPanel(chartX2);
        chartX2.setBackgroundPaint(new GradientPaint(0, 0, Color.white, 1000, 1000, new Color(255, 180, 180)));
        chartX2.getPlot().setBackgroundPaint( new Color(220, 220, 220));
        chartX2.getXYPlot().setDomainGridlinePaint(new Color(50, 50, 50));
        chartX2.getXYPlot().setRangeGridlinePaint(new Color(50, 50, 50));

        x3Dataset = new XYSeriesCollection();
        chartX3 = ChartFactory.createXYLineChart("Функция Y(X3)",
                "X3", "Функция Y(X3)", x3Dataset, PlotOrientation.VERTICAL, true, false, false);
        thirdParameterPLot = new ChartPanel(chartX3);
        chartX3.setBackgroundPaint(new GradientPaint(0, 0, Color.white, 1000, 1000, new Color(180, 180, 255)));
        chartX3.getPlot().setBackgroundPaint( new Color(220, 220, 220));
        chartX3.getXYPlot().setDomainGridlinePaint(new Color(50, 50, 50));
        chartX3.getXYPlot().setRangeGridlinePaint(new Color(50, 50, 50));

        resultDataset = new XYSeriesCollection();
        chartResult = ChartFactory.createScatterPlot("Функция Y(Xn)",
                "N", "Функция Y(Xn)", resultDataset, PlotOrientation.VERTICAL, true, false, false);
        resultPLot = new ChartPanel(chartResult);
        chartResult.setBackgroundPaint(new GradientPaint(0, 0, Color.white, 1000, 1000, new Color(255, 255, 180)));
        chartResult.getPlot().setBackgroundPaint( new Color(220, 220, 220));
        chartResult.getXYPlot().setDomainGridlinePaint(new Color(50, 50, 50));
        chartResult.getXYPlot().setRangeGridlinePaint(new Color(50, 50, 50));

        resultPlotGotPlot = (XYPlot) chartResult.getPlot();
        resultPlotRenderer = new XYLineAndShapeRenderer();

        x1Results = new ResultsPanel(lineNumber);
        x2Results = new ResultsPanel(lineNumber);
        x3Results = new ResultsPanel(lineNumber);

        //add panels to tab widget
        add("Данные", showDataPanel);
        add("Таблица X1", x1Results);
        add("Таблица X2", x2Results);
        add("Таблица X3", x3Results);
        add("X1", firstParameterPLot);
        add("X2", secondParameterPLot);
        add("X3", thirdParameterPLot);
        add("Результаты", resultPLot);
    }

    public void clearCharts() {
        x1Dataset.removeAllSeries();
        x2Dataset.removeAllSeries();
        x3Dataset.removeAllSeries();
        resultDataset.removeAllSeries();
    }
}