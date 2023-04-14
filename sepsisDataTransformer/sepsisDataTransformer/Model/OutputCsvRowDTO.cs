namespace sepsisDataTransformer.Model;

public record OutputCsvRowDTO
{
    public string ID { get; set; }
    public int PRG { get; set; }
    public int PL { get; set; }
    public int PR { get; set; }
    public int SK { get; set; }
    public int TS { get; set; }
    public double? M11 { get; set; }
    public double? BD2 { get; set; }
    public int? Age { get; set; }
    public int Insurance { get; set; }

    public double? HR { get; set; }
    public double? O2Sat { get; set; }
    public double? Temp { get; set; }
    public double? Resp { get; set; }
    public string EtCO2 { get; set; }
    public double? BaseExcess { get; set; }
    public double? HCO3 { get; set; }
    public double? FiO2 { get; set; }
    public double? pH { get; set; }
    public double? PaCO2 { get; set; }
    public double? SaO2 { get; set; }
    public double? AST { get; set; }
    public double? BUN { get; set; }
    public double? Alkalinephos { get; set; }
    public double? Calcium { get; set; }
    public double? Chloride { get; set; }
    public double? Creatinine { get; set; }
    public string Bilirubin_direct { get; set; }
    public double? Lactate { get; set; }
    public double? Magnesium { get; set; }
    public double? Phosphate { get; set; }
    public double? Potassium { get; set; }
    public double? Bilirubin_total { get; set; }
    public string TroponinI { get; set; }
    public double? Hct { get; set; }
    public double? Hgb { get; set; }
    public double? PTT { get; set; }
    public double? WBC { get; set; }
    public string Fibrinogen { get; set; }
    public double? Platelets { get; set; }
    public int? Gender { get; set; }

    public int Sepssis { get; set; }

    public OutputCsvRowDTO(AdditionCsvRowDTO additionCsvRowDTO)
    {
        Sepssis = Convert.ToInt32(additionCsvRowDTO.SepsisLabel);
        ID = additionCsvRowDTO.ID;
        Age = Convert.ToInt32(additionCsvRowDTO.Age);
        PRG = (int)ScaleGlucose(Convert.ToInt32(additionCsvRowDTO.Glucose), 9, 999, 0, 9);
        var bpARR = new double?[] { Convert.ToDouble(additionCsvRowDTO.SBP), Convert.ToDouble(additionCsvRowDTO.MAP), Convert.ToDouble(additionCsvRowDTO.DBP) };
        PR = (int)bpARR.Average();
        //the rest of the fields
        HR = additionCsvRowDTO.HR;
        O2Sat = additionCsvRowDTO.O2Sat;
        Temp = additionCsvRowDTO.Temp;
        Resp = additionCsvRowDTO.Resp;
        EtCO2 = additionCsvRowDTO.EtCO2;
        BaseExcess = additionCsvRowDTO.BaseExcess;
        HCO3 = additionCsvRowDTO.HCO3;
        FiO2 = additionCsvRowDTO.FiO2;
        pH = additionCsvRowDTO.pH;
        PaCO2 = additionCsvRowDTO.PaCO2;
        SaO2 = additionCsvRowDTO.SaO2;
        AST = additionCsvRowDTO.AST;
        BUN = additionCsvRowDTO.BUN;
        Alkalinephos = additionCsvRowDTO.Alkalinephos;
        Calcium = additionCsvRowDTO.Calcium;
        Chloride = additionCsvRowDTO.Chloride;
        Creatinine = additionCsvRowDTO.Creatinine;
        Bilirubin_direct = additionCsvRowDTO.Bilirubin_direct;
        Lactate = additionCsvRowDTO.Lactate;
        Magnesium = additionCsvRowDTO.Magnesium;
        Phosphate = additionCsvRowDTO.Phosphate;
        Potassium = additionCsvRowDTO.Potassium;
        Bilirubin_total = additionCsvRowDTO.Bilirubin_total;
        TroponinI = additionCsvRowDTO.TroponinI;
        Hct = additionCsvRowDTO.Hct;
        Hgb = additionCsvRowDTO.Hgb;
        PTT = additionCsvRowDTO.PTT;
        WBC = additionCsvRowDTO.WBC;
        Fibrinogen = additionCsvRowDTO.Fibrinogen;
        Platelets = additionCsvRowDTO.Platelets;
        Gender = additionCsvRowDTO.Gender;
    }


    public OutputCsvRowDTO(SourceCsvRowDTO sourceCsvRowDTO)
    {
        ID = sourceCsvRowDTO.ID;
        PRG = sourceCsvRowDTO.PRG;
        PL = sourceCsvRowDTO.PL;
        PR = sourceCsvRowDTO.PR;
        SK = sourceCsvRowDTO.SK;
        TS = sourceCsvRowDTO.TS;
        M11 = sourceCsvRowDTO.M11;
        BD2 = sourceCsvRowDTO.BD2;
        Age = sourceCsvRowDTO.Age;
        Insurance = sourceCsvRowDTO.Insurance;
        Sepssis = sourceCsvRowDTO.Sepssis == "Positive" ? 1 : 0;
    }


    private double? ScaleGlucose(int value, int min, int max, int minScale, int maxScale)
    {
        var scaled = minScale + (double?)(value - min) / (max - min) * (maxScale - minScale);
        return scaled;
    }
}