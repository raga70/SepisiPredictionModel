using sepsisDataTransformer;
using sepsisDataTransformer.Model;
using ServiceStack;

var inputCSVpath = "";
var additionCSVpath = "";
var outputCSVpath = "";
if (args.Contains("--inputCSV"))
{
    inputCSVpath = args[args.ToList().IndexOf("--inputCSV") + 1];
}
else
{
    Console.WriteLine(
        "Usage: sepsisDataTransformer --inputCSV <path to input csv> --additionCSV <path to addition csv> --outputCSV <path to output CSV>");
    return;
}

if (args.Contains("--outputCSV"))
{
    outputCSVpath = args[args.ToList().IndexOf("--outputCSV") + 1];
}
else
{
    Console.WriteLine(
        "Usage: sepsisDataTransformer --inputCSV <path to input csv> --additionCSV <path to addition csv> --outputCSV <path to output CSV>");
    return;
}

if (args.Contains("--additionCSV"))
{
    additionCSVpath = args[args.ToList().IndexOf("--additionCSV") + 1];
}
else
{
    Console.WriteLine(
        "Usage: sepsisDataTransformer --inputCSV <path to input csv> --additionCSV <path to addition csv> --outputCSV <path to output CSV>");
    return;
}

Console.WriteLine("\n");
ServiceStack.Text.CsvConfig.ItemSeperatorString = ",";

List<SourceCsvRowDTO> sourceCsvRowDtos = File.ReadAllText(inputCSVpath).FromCsv<List<SourceCsvRowDTO>>();
List<AdditionCsvRowDTO> additionCsvRowDtos = File.ReadAllText(additionCSVpath).FromCsv<List<AdditionCsvRowDTO>>();
var Output = new Transformer(sourceCsvRowDtos,additionCsvRowDtos).Transform();
var a = 1;
File.WriteAllText(outputCSVpath, Output.ToCsv());