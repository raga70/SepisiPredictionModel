﻿from datetime import datetime

from pydantic import BaseModel
class PredictRequestDTO(BaseModel):
    patientID: str
    PL: int
    Age: int
    M11: float
    PR: int
    TS: int
    