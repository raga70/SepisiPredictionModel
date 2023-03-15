import DataStorage
from Model.Patient import Patient


def PatientsRequringExtraAttention():
    Todayspatiens: list[Patient] = DataStorage.retrieveTodaysPatients()
    patients: list[Patient] = []
    for patient in Todayspatiens:
        if patient.sepsisPrediction == 1:
            patients.append(patient)
    patients.sort(key=lambda x: x.certainty, reverse=True)
    return patients