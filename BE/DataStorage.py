import sqlite3
from datetime import datetime
from Model.PredictionRequestDTO import PredictRequestDTO
from Model.Patient import Patient


def createTable():
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute('''CREATE TABLE IF NOT EXISTS patients
                 (patientID TEXT, sepsisPrediction INTEGER, accuracy REAL, date TEXT, PL INTEGER, Age INTEGER, M11 REAL, PR INTEGER, TS INTEGER)''')
    conn.commit()
    conn.close()

def insertPatient(patient):
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute("INSERT INTO patients VALUES (?,?, ?, ?, ?, ?, ?, ?, ?)", (patient.patientID, patient.sepsisPrediction, patient.certainty, patient.date, patient.PL, patient.Age, patient.M11, patient.PR, patient.TS))
    conn.commit()
    conn.close()

def retrieveAllpatients():
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute("SELECT * FROM patients")
    rows = c.fetchall()
    patients = []
    for row in rows:
        patient = Patient(row[0], row[1], row[2],  datetime.strptime(row[3], '%Y-%m-%d %H:%M:%S.%f'), row[4], row[5], row[6], row[7], row[8])
        patients.append(patient)
    conn.close()
    return patients

def retrieveTodaysPatients():
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute("SELECT * FROM patients WHERE date >= date('now', 'start of day')")
    rows = c.fetchall()
    patients = []
    for row in rows:
        patientRequestDTO:PredictRequestDTO = PredictRequestDTO(patientID=row[0], PL=row[4], Age=row[5], M11=row[6], PR=row[7], TS=row[8])
        patient = Patient(patientRequestDTO, row[1], row[2])
        patients.append(patient)
    conn.close()
    return patients



