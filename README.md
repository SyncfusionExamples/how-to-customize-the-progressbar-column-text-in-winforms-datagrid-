# How to customize the ProgressBarColumn text in WinForms DataGrid (SfDataGrid)?

How to customize the ProgressBarColumn text in WinForms DataGrid (SfDataGrid)?

# About the sample

By default, SfDataGrid GridProgressBarColumn have maximum value as 100, you can change the this by overriding the OnRender method in GridProgressBarColumnCellRenderer class.
```c#
this.sfDataGrid.CellRenderers.Remove("ProgressBar");
this.sfDataGrid.CellRenderers.Add("ProgressBar", new GridProgressBarColumnExt(new ProgressBarAdv()));
public class GridProgressBarColumnExt : GridProgressBarCellRenderer
{
    ProgressBarAdv ProgressBar;
    public GridProgressBarColumnExt(ProgressBarAdv progressBar) : base(progressBar)
    {
        ProgressBar = progressBar;
    }

    protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
    {
        ProgressBar.CustomText = cellValue + "%";
        ProgressBar.TextStyle = ProgressBarTextStyles.Custom;
        decimal decimalvalue = decimal.Parse(cellValue);
        var intvalue = decimal.ToInt32(decimalvalue);
        cellValue = intvalue.ToString();
        base.OnRender(paint, cellRect, cellValue, style, column, rowColumnIndex);
    }
}

```
## Requirements to run the demo
 Visual Studio 2015 and above versions
