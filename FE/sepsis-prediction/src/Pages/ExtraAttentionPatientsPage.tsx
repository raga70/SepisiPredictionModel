﻿import {useEffect, useState} from "react";
import {PatientResponceDTO} from "../Model/PatientResponceDTO";
import {getExtraAttentionPatients} from "../api";
import {Input,Button, Card, Typography} from '@mui/joy';
export const ExtraAttentionPatientsPage = () => {

    const [patients, setPatients] = useState<PatientResponceDTO[]>([]);

    useEffect(() => {
       getExtraAttentionPatients().then((resp)=>{setPatients(resp)})
        
        
    }, []);

    const convertResult = (result: number) => {
        if (result === 1) {
            return "Positive"
        } else {
            return "Negative"
        }
    }
    const convertCertaintyResult = (result: number) => {
        return result*100 + "%"
    }
   
    return (
        <div style={{display:"grid" , marginTop:30, alignItems:"center", justifyContent:"space-around"}}>
            {patients.map((patient)=>(
                <Card variant="outlined" sx={{ width: 320 }}>
                    <Typography level="h1" fontSize="md" sx={{ mb: 0.5 }}>
                        #: {patient.patientID}
                    </Typography>
                    <br/>
                    <Typography level="h3" style={{fontWeight:"bold"}} fontSize="md" sx={{ mb: 0.5 }}>Result: {convertResult(patient.sepsisPrediction)}</Typography>
                    <Typography level="h3" style={{fontWeight:"bold"}} fontSize="md" sx={{ mb: 0.5 }}>Certainty: {convertCertaintyResult(patient.certainty)}</Typography>
                    <br/>
                    <br/>
                    <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>Age: {patient.Age}</Typography>
                    <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>M11: {patient.M11}</Typography>
                    <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>PL: {patient.PL}</Typography>
                    <Typography style={{fontWeight:"lighter"}} fontSize="sm" sx={{ mb: 0.5 }}>PR: {patient.PR}</Typography>
                    <Typography style={{fontWeight:"lighter"}} fontSize="sm" sx={{ mb: 0.5 }}>TS: {patient.TS}</Typography>
                </Card>
                ))}
        </div>
    )
}
export default ExtraAttentionPatientsPage