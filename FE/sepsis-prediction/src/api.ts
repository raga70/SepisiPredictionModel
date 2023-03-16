import {ExtraAttentionPatients_URL, Predict_URL} from "./app.properties";
import {PatientRequestDTO} from "./Model/PatientRequestDTO";
import {PatientResponceDTO} from "./Model/PatientResponceDTO";
import axios from "axios";
export const enterPatirnt = async (patient: PatientRequestDTO):Promise<PatientResponceDTO> => {
   let resp = await axios.post(Predict_URL, patient);
    return resp.data;
}

export const getExtraAttentionPatients = async ():Promise<PatientResponceDTO[]>  => {
    let resp = await axios.get(ExtraAttentionPatients_URL);
    return resp.data;
}