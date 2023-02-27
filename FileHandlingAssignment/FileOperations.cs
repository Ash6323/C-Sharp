using System;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.CompoundDocumentFormat;
internal class FileOperations
{
	internal void CopyFile(string sourceFilePath)
	{
		string destinationFilePath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\ResourceFiles\\CopyFolder\\"+ $"{Path.GetFileName(sourceFilePath)}";
        File.Copy(sourceFilePath, destinationFilePath);
        Console.WriteLine("File Copied to Destination Folder...\n");
    }
    internal void MoveFile(string sourceFilePath)
    {
        string destinationFilePath = @"E:\\Work\\IncubXperts\\C-Sharp\\FileHandlingAssignment\\ResourceFiles\\CopyFolder\\" + $"{Path.GetFileName(sourceFilePath)}";
        File.Move(sourceFilePath, destinationFilePath);
        Console.WriteLine("File Moved to Destination Folder...\n");
    }
    internal void DeleteFile(string sourceFilePath)
    {
        File.Delete(sourceFilePath);
        Console.WriteLine("File Deleted from Folder...\n");
    }
    internal void AppendToFile(string sourceFilePath)
    {
        Console.Write("Enter the Text to Append: ");
        string textToAppend = Console.ReadLine();
        using (StreamWriter sw = File.AppendText(sourceFilePath))
        {
            sw.WriteLine(textToAppend);
        }
        Console.Write("Text Appended to File...\n");
    }
    internal void OverWriteFile(string sourceFilePath)
    {
        Console.Write("Enter the Text to Overwrite: ");
        string textToAppend = Console.ReadLine();
        using (TextWriter textWriter = File.CreateText(sourceFilePath))
        {
            textWriter.WriteLine(textToAppend);
        }
        Console.Write("Text is Overwritten to File...\n");
    }
    internal void ExcelOperation(string sourceFilePath)
    {
        Workbook workbook = new Workbook(); 
        Worksheet worksheet = new Worksheet("Sheet1"); 
        Console.Write("Please Enter Heading: ");
        string headingforExcelFile = Console.ReadLine();
        worksheet.Cells[0, 2] = new Cell(headingforExcelFile);
        int numberOfRows, numberOfColumns;
        while (true)
        {
            Console.Write("Please Enter Number of Rows (Maximum 3): ");
            numberOfRows = Convert.ToInt32(Console.ReadLine());
            if (numberOfRows < 1 || numberOfRows > 3)
            {
                Console.WriteLine(ConstantMessagesForOutput.invalidNumberOfRows);
                continue;
            }
            Console.Write("Please Enter Number of Columns (Maximum 5): ");
            numberOfColumns = Convert.ToInt32(Console.ReadLine());
            if (numberOfColumns < 1 || numberOfColumns > 5)
            {
                Console.WriteLine(ConstantMessagesForOutput.invalidNumberOfColumns);
                continue;
            }
            else
                break;
        }
        Console.WriteLine("\nEnter the Content- ");
        for(int i= 2; i<numberOfRows+2; i++)
        {
            for(int j= 0; j<numberOfColumns; j++)
            {
                Console.Write($"Cell [{i-2},{j}]: ");
                worksheet.Cells[i,j] = new Cell(Console.ReadLine());
            }
        }
        workbook.Worksheets.Add(worksheet);
        workbook.Save(sourceFilePath);
        Console.WriteLine("Excel File Edited...\n");

        //For Write
        //worksheet.Cells[2, 0] = new Cell("Hello"); 
        //worksheet.Cells[2, 1] = new Cell("This");
        //worksheet.Cells[2, 2] = new Cell("is");
        //worksheet.Cells[2, 3] = new Cell("a");
        //worksheet.Cells[2, 4] = new Cell("Row"); 
        //worksheet.Cells[4, 2] = new Cell(DateTime.Now.ToString("dd/MM/yyyy"));
        //workbook.Worksheets.Add(worksheet); 
        //workbook.Save(sourceFilePath);

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
