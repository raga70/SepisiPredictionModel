from datetime import datetime

from pydantic import BaseModel

from Model.PredictionRequestDTO import PredictRequestDTO


class Patient(BaseModel):
    sepsisPrediction: int
    certainty: float
    date: datetime
    PL: int
    Age: int
    M11: float
    PR: int
    TS: int
    def __init__(self, patientRequestDTO:PredictRequestDTO, sepsisPrediction, certainty):
        self.patientID = patientRequestDTO.patientID
        self.sepsisPrediction = sepsisPrediction
        self.certainty = certainty
        self.PL = patientRequestDTO.PL
        self.Age = patientRequestDTO.Age
        self.M11 = patientRequestDTO.M11
        self.PR = patientRequestDTO.PR
        self.TS = patientRequestDTO.TS
        self.date = datetime.now()