using GradingSystem;
using System;

try
{
    var processor = new StudentResultProcessor();
    
    // Paths - CHANGE THESE TO YOUR ACTUAL FILE PATHS
    string inputFile = "students.txt";
    string outputFile = "report.txt";

    // Process data
    var students = processor.ReadStudentsFromFile(inputFile);
    processor.WriteReportToFile(students, outputFile);

    Console.WriteLine($"Successfully processed {students.Count} students. Report saved to {outputFile}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: Input file not found - {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}