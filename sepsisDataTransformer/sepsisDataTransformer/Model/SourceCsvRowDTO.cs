namespace sepsisDataTransformer.Model;

public record SourceCsvRowDTO
{
    public string ID { get; set; }
    public int PRG { get; set; }
    public int PL { get; set; }
    public int PR { get; set; }
    public int SK { get; set; }
    public int TS { get; set; }
    public double M11 { get; set; }
    public double BD2 { get; set; }
    public int Age { get; set; }
    public int Insurance { get; set; }
    public string Sepssis { get; set; }
}