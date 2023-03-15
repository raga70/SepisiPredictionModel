from fastapi import FastAPI

import DataStorage
from ExtraAttentionPatientsManager import PatientsRequringExtraAttention
from Model.PredictionRequestDTO import PredictRequestDTO
from sepsisPredictor import predict

app = FastAPI()


@app.get("/")
async def root():
    return {"message": "Hello World"}


@app.get("/predict/")
async def predictEndpoint(predictRequest: PredictRequestDTO):
    result = await predict(predictRequest)
    await DataStorage.insertPatient(result)
    return result

@app.get("/ExtraAttentionPatients/")
async def ExtraAttentionPatientsEndpoint():
    return await PatientsRequringExtraAttention()