using System.Collections.Concurrent;
using sepsisDataTransformer.Model;
using ServiceStack;

namespace sepsisDataTransformer;

public class Transformer
{
    private List<SourceCsvRowDTO> _sourceCsvRowDtos;
    private List<AdditionCsvRowDTO> _additionCsvRowDtos;

    public Transformer(List<SourceCsvRowDTO> sourceCsvRows, List<AdditionCsvRowDTO> additionCsvRows)
    {
        _sourceCsvRowDtos = sourceCsvRows;
        _additionCsvRowDtos = additionCsvRows;
    }

    public List<OutputCsvRowDTO> Transform()
    {
        List<OutputCsvRowDTO> outputCsvRowDtos = new();
        //select the avarage of all fields from the addition csv file where the sepsis field is positive and ID in unique
        List<AdditionCsvRowDTO> avgResultofPostiveSepsisPatientsInLateStage = _additionCsvRowDtos
            .Where(x => x.SepsisLabel == "1").GroupBy(x => x.Patient_ID).Select(x => new AdditionCsvRowDTO
            {
                 ID = x.First().Patient_ID,
                        HR = x.Average(y => y.HR),
                        O2Sat = x.Average(y => y.O2Sat),
                        Temp = x.Average(y => y.Temp),
                        SBP = x.Average(y => y.SBP),
                        MAP = x.Average(y => y.MAP),
                        DBP = x.Average(y => y.DBP),
                        Resp = x.Average(y => y.Resp),
                        EtCO2 = x.First().EtCO2,
                        BaseExcess = x.Average(y => y.BaseExcess),
                        HCO3 = x.Average(y => y.HCO3),
                        FiO2 = x.Average(y => y.FiO2),
                        pH = x.Average(y => y.pH),
                        PaCO2 = x.Average(y => y.PaCO2),
                        SaO2 = x.Average(y => y.SaO2),
                        AST = x.Average(y => y.AST),
                        BUN = x.Average(y => y.BUN),
                        Alkalinephos = x.Average(y => y.Alkalinephos),
                        Calcium = x.Average(y => y.Calcium),
                        Chloride = x.Average(y => y.Chloride),
                        Creatinine = x.Average(y => y.Creatinine),
                        Bilirubin_direct = x.First().EtCO2,
                        Glucose = x.Average(y => y.Glucose),
                        Lactate = x.Average(y => y.Lactate),
                        Magnesium = x.Average(y => y.Magnesium),
                        Phosphate = x.Average(y => y.Phosphate),
                        Potassium = x.Average(y => y.Potassium),
                        Bilirubin_total = x.Average(y => y.Bilirubin_total),
                        TroponinI = x.First().EtCO2,
                        Hct = x.Average(y => y.Hct),
                        PTT = x.Average(y => y.PTT),
                        Hgb = x.Average(y => y.Hgb),
                        WBC = x.Average(y => y.WBC),
                        Fibrinogen = x.First().EtCO2,
                        Platelets = x.Average(y => y.Platelets),
                        Age = x.First().Age,
                        Gender = x.First().Gender,
                        SepsisLabel = x.First().SepsisLabel,
                        Patient_ID = x.First().SepsisLabel
            }).ToList();


        List<AdditionCsvRowDTO> tmpListWithAllRowsWhereSepsisIsNegative =
            _additionCsvRowDtos.Where(x => x.SepsisLabel == "0").ToList();
        ConcurrentBag<string> avgResultOfNegativePatientsPatientIDS = new();
        ConcurrentBag<AdditionCsvRowDTO> avgResultOfNegativePatients = new();
        List<string> positiveSepsisPatientIds = avgResultofPostiveSepsisPatientsInLateStage
            .Select(x => x.Patient_ID)
            .ToList();

        Parallel.ForEach(tmpListWithAllRowsWhereSepsisIsNegative.AsParallel().AsOrdered(), (row, state) =>
        {
           
            if ( positiveSepsisPatientIds.Contains(row.Patient_ID) || avgResultOfNegativePatientsPatientIDS.Contains(row.Patient_ID))
            {
                return;
            }
            else
            {

                avgResultOfNegativePatientsPatientIDS.Add(row.Patient_ID);
                avgResultOfNegativePatients.Add(_additionCsvRowDtos.Where(x => x.Patient_ID == row.Patient_ID)
                    .GroupBy(x => x.Patient_ID).Select(x => new AdditionCsvRowDTO
                    {
                        ID = x.First().Patient_ID,
                        HR = x.Average(y => y.HR),
                        O2Sat = x.Average(y => y.O2Sat),
                        Temp = x.Average(y => y.Temp),
                        SBP = x.Average(y => y.SBP),
                        MAP = x.Average(y => y.MAP),
                        DBP = x.Average(y => y.DBP),
                        Resp = x.Average(y => y.Resp),
                        EtCO2 = x.First().EtCO2,
                        BaseExcess = x.Average(y => y.BaseExcess),
                        HCO3 = x.Average(y => y.HCO3),
                        FiO2 = x.Average(y => y.FiO2),
                        pH = x.Average(y => y.pH),
                        PaCO2 = x.Average(y => y.PaCO2),
                        SaO2 = x.Average(y => y.SaO2),
                        AST = x.Average(y => y.AST),
                        BUN = x.Average(y => y.BUN),
                        Alkalinephos = x.Average(y => y.Alkalinephos),
                        Calcium = x.Average(y => y.Calcium),
                        Chloride = x.Average(y => y.Chloride),
                        Creatinine = x.Average(y => y.Creatinine),
                        Bilirubin_direct = x.First().EtCO2,
                        Glucose = x.Average(y => y.Glucose),
                        Lactate = x.Average(y => y.Lactate),
                        Magnesium = x.Average(y => y.Magnesium),
                        Phosphate = x.Average(y => y.Phosphate),
                        Potassium = x.Average(y => y.Potassium),
                        Bilirubin_total = x.Average(y => y.Bilirubin_total),
                        TroponinI = x.First().EtCO2,
                        Hct = x.Average(y => y.Hct),
                        PTT = x.Average(y => y.PTT),
                        Hgb = x.Average(y => y.Hgb),
                        WBC = x.Average(y => y.WBC),
                        Fibrinogen = x.First().EtCO2,
                        Platelets = x.Average(y => y.Platelets),
                        Age = x.First().Age,
                        Gender = x.First().Gender,
                        SepsisLabel = x.First().SepsisLabel,
                        Patient_ID = x.First().SepsisLabel
                    }).First());
                Console.Write("\r{0}                                        ", "Found  Negative distinct patients: " + avgResultOfNegativePatients.Count + " in the: " + tmpListWithAllRowsWhereSepsisIsNegative.Count);
            }

            // if(avgResultOfNegativePatients.Count == 5000)
            //     state.Break();  
                
        });

        outputCsvRowDtos.AddRange( _sourceCsvRowDtos.Select(x => new OutputCsvRowDTO(x)).ToList());
        outputCsvRowDtos.AddRange(avgResultofPostiveSepsisPatientsInLateStage.Select(x => new OutputCsvRowDTO(x))
            .ToList());
        outputCsvRowDtos.AddRange(avgResultOfNegativePatients.Select(x => new OutputCsvRowDTO(x)).ToList());


        return outputCsvRowDtos;
    }
}