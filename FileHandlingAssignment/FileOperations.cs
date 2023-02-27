using System;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;
internal class FileOperations
{
	internal void CopyFile(string sourceFilePath)
	{
		string destinationFilePath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\ResourceFiles\\CopyFolder\\"+ $"{Path.GetFileName(sourceFilePath)}";
        File.Copy(sourceFilePath, destinationFilePath);
        //string lines = File.ReadAllText(destinationFilePath);
        //Console.WriteLine(lines);
        Console.WriteLine("File Copied to Destination Folder...");
    }
    internal void MoveFile(string sourceFilePath)
    {
        string destinationFilePath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\ResourceFiles\\CopyFolder\\" + $"{Path.GetFileName(sourceFilePath)}";
        File.Move(sourceFilePath, destinationFilePath);
        Console.WriteLine("File Moved to Destination Folder...");
    }
    internal void AppendToFile(string sourceFilePath)
    {
        Console.Write("Enter the Text to Append: ");
        string textToAppend = Console.ReadLine();
        using (StreamWriter sw = File.AppendText(sourceFilePath))
        {
            sw.WriteLine(textToAppend);
        }
        Console.Write("Text Appended to File...");
    }
    internal void OverWriteFile(string sourceFilePath)
    {
        Console.Write("Enter the Text to Append: ");
        string textToAppend = Console.ReadLine();
        using (TextWriter textWriter = File.CreateText(sourceFilePath))
        {
            textWriter.WriteLine(textToAppend);
        }
        Console.Write("Text is Overwritten to File...");
    }
    internal void ExcelOperation(string sourceFilePath)
    {
        Workbook workbook = new Workbook(); 
        Worksheet worksheet = new Worksheet("Sheet1"); 
        worksheet.Cells[2, 0] = new Cell("Hello"); 
        worksheet.Cells[2, 1] = new Cell("This");
        worksheet.Cells[2, 2] = new Cell("is");
        worksheet.Cells[2, 3] = new Cell("a");
        worksheet.Cells[2, 4] = new Cell("Row"); 
        worksheet.Cells[4, 2] = new Cell(DateTime.Now.ToString("dd/MM/yyyy"));
        workbook.Worksheets.Add(worksheet); 
        workbook.Save(sourceFilePath);
        Console.WriteLine("\nExcel File Edited...");

        //For Read
        //sourceFilePath = Path.GetFileName(sourceFilePath);
        //Workbook book = Workbook.Load(sourceFilePath); 
        //Worksheet sheet = book.Worksheets[0];

        //for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++) 
        //{ Row row = sheet.Cells.GetRow(rowIndex); 
        //    for (int colIndex = row.FirstColIndex; 
        //        colIndex <= row.LastColIndex; colIndex++) 
        //    { 
        //        Cell cell = row.GetCell(colIndex); 
        //    } 
        //}
    }
}
