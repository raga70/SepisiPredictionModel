import sqlite3
from datetime import datetime

from Model.Patient import Patient


# def createTable():
#     conn = sqlite3.connect('patients.db')
#     c = conn.cursor()
#     c.execute('''CREATE TABLE IF NOT EXISTS patients
#                  (sepsisPrediction INTEGER, accuracy REAL, date TEXT, PL INTEGER, Age INTEGER, M11 REAL, PR INTEGER, TS INTEGER)''')
#     conn.commit()
#     conn.close()

def insertPatient(patient):
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute("INSERT INTO patients VALUES (?, ?, ?, ?, ?, ?, ?, ?)", (patient.sepsisPrediction, patient.certainty, patient.date, patient.PL, patient.Age, patient.M11, patient.PR, patient.TS))
    conn.commit()
    conn.close()

def retrieveAllpatients():
    conn = sqlite3.connect('patients.db')
    c = conn.cursor()
    c.execute("SELECT * FROM patients")
    rows = c.fetchall()
    patients = []
    for row in rows:
        patient = Patient(row[0], row[1], datetime.strptime(row[2], '%Y-%m-%d %H:%M:%S.%f'), row[3], row[4], row[5], row[6], row[7])
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
        patient = Patient(row[0], row[1], datetime.strptime(row[2], '%Y-%m-%d %H:%M:%S.%f'), row[3], row[4], row[5], row[6], row[7])
        patients.append(patient)
    conn.close()
    return patients



