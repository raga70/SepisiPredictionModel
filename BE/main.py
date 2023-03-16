from fastapi import FastAPI

import DataStorage
from ExtraAttentionPatientsManager import PatientsRequringExtraAttention
from Model.PredictionRequestDTO import PredictRequestDTO
from sepsisPredictor import predict
from fastapi.middleware.cors import CORSMiddleware
app = FastAPI()


origins = [
    
    "http://localhost",
    "http://localhost:3000",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins="*",
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)



@app.get("/")
async def root():
    return {"message": "Hello World"}


@app.post("/predict")
async def predictEndpoint(predictRequest: PredictRequestDTO):
    result =  predict(predictRequest)
    DataStorage.insertPatient(result)
    return result

@app.get("/ExtraAttentionPatients")
async def ExtraAttentionPatientsEndpoint():
    DataStorage.createTable()
    return  PatientsRequringExtraAttention()