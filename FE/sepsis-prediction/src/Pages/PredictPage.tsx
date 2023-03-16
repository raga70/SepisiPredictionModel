import {Input,Button, Card, Typography} from '@mui/joy';
import {useState} from "react";
import {PatientRequestDTO} from "../Model/PatientRequestDTO";
import {PatientResponceDTO} from "../Model/PatientResponceDTO";
import {enterPatirnt} from "../api";


export const PredictPage = () => {

    const [newPatient, setNewPatient] = useState<PatientRequestDTO>({Age: 0, M11: 0, PL: 0, PR: 0, TS: 0, patientID: ""} );

    // @ts-ignore
    const [ResultPatient, setResultPatient] = useState<PatientResponceDTO>(undefined);

    const convertResult = (result: number) => {
        if (result === 1) {
            return "Positive"
        } else {
            return "Negative"
        }
    }
    
    
    const SubmitPatient = async () =>{
        let response = await enterPatirnt(newPatient)
        setResultPatient(response)
    }
    
    
    return (
        ResultPatient == undefined ?
        <>
            <div style={{display:"flex" , marginTop:30, alignItems:"center", justifyContent:"space-around"}}>
                
                <div>
                    <label style={{marginRight:10}}>Patient ID</label>               
                    <Input style={{ color:"#545C52"}}  color="info" name="patientID" placeholder="####" value={newPatient.patientID} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
                <div>
                    <label style={{marginRight:10}}>Age</label>
                    <Input style={{ color:"#545C52"}}  type="number" color="info" name="Age" placeholder="" value={newPatient.Age} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
                <div>
                    <label style={{marginRight:10}}>M11: Body mass index</label>
                    <Input style={{ color:"#545C52"}}  type="number" color="info" name="M11" placeholder="" value={newPatient.M11} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
                <div>
                    <label style={{marginRight:10}}>PL: Blood Work Result-1 (mu U/ml)</label>
                    <Input style={{ color:"#545C52"}}  type="number" color="info" name="PL" placeholder="" value={newPatient.PL} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
                <div>
                    <label style={{marginRight:10}}>PR: Blood Pressure (mm Hg)</label>
                    <Input style={{ color:"#545C52"}}  type="number" color="info" name="PR" placeholder="" value={newPatient.PR} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
                <div>
                    <label style={{ marginRight:10}}>TS: Blood Work Result-3 (mu U/ml)</label>
                    <Input style={{ color:"#545C52"}} type="number" color="info" name="TS" placeholder="" value={newPatient.TS} onChange={(e)=>{setNewPatient({...newPatient,[e.target.name]:e.target.value})}} size="md" />
                </div>
             
            </div>
            <div style={{display:"flex" , marginTop:30, alignItems:"center", justifyContent:"space-around"}}>
                <Button
                    style={{backgroundColor:"#98E2C6", color:"#545C52"}}
                    onClick={SubmitPatient}
                    size="md"
                    variant="solid"
                >
                    Submit
                </Button>    
             </div>
       </> 
       : 
       <>
           <div style={{display:"flex" , marginTop:30, alignItems:"center", justifyContent:"space-around"}}>
               <Card variant="outlined" sx={{ width: 320 }}>
                   <Typography level="h1" fontSize="md" sx={{ mb: 0.5 }}>
                      #: {ResultPatient.patientID}
                   </Typography>
                   <br/>
                   <Typography level="h3" style={{fontWeight:"bold"}} fontSize="md" sx={{ mb: 0.5 }}>Result:{convertResult(ResultPatient.sepsisPrediction)}</Typography>
                   <Typography level="h3" style={{fontWeight:"bold"}} fontSize="md" sx={{ mb: 0.5 }}>Certainty:{ResultPatient.certainty}</Typography>
                   <br/>
                   <br/>
                   <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>Age:{ResultPatient.Age}</Typography>
                   <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>M11:{ResultPatient.M11}</Typography>
                   <Typography style={{fontWeight:"lighter"}}  fontSize="sm" sx={{ mb: 0.5 }}>PL:{ResultPatient.PL}</Typography>
                   <Typography style={{fontWeight:"lighter"}} fontSize="sm" sx={{ mb: 0.5 }}>PR:{ResultPatient.PR}</Typography>
                   <Typography style={{fontWeight:"lighter"}} fontSize="sm" sx={{ mb: 0.5 }}>TS:{ResultPatient.TS}</Typography>
               </Card>
           </div>    
       </>
        
    )
}
export default PredictPage