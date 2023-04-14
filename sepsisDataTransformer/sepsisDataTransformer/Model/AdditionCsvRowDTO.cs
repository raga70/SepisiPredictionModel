namespace sepsisDataTransformer.Model;

public record AdditionCsvRowDTO
{
//columns: ID,Hour,HR,O2Sat,Temp,SBP,MAP,DBP,Resp,EtCO2,BaseExcess,HCO3,FiO2,pH,PaCO2,SaO2,AST,BUN,Alkalinephos,Calcium,Chloride,Creatinine,Bilirubin_direct,Glucose,Lactate,Magnesium,Phosphate,Potassium,Bilirubin_total,TroponinI,Hct,Hgb,PTT,WBC,Fibrinogen,Platelets,Age,Gender,Unit1,Unit2,HospAdmTime,ICULOS,SepsisLabel,Patient_ID
    public string? ID { get; set; }
    public int? Hour { get; set; }
    public double? HR { get; set; }
    public double? O2Sat { get; set; }
    public double? Temp { get; set; }
    public double? SBP { get; set; }
    public double? MAP { get; set; }
    public double? DBP { get; set; }
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
    public double? Glucose { get; set; }
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
    public double? Age { get; set; }
    public int Gender { get; set; }
    public double? Unit1 { get; set; }
    public double? Unit2 { get; set; }
    public double? HospAdmTime { get; set; }
    public string? ICULOS { get; set; }
    public string? SepsisLabel { get; set; }
    public string? Patient_ID { get; set; }
}