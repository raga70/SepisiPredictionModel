import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ExtraAttentionPatientsPage from "./Pages/ExtraAttentionPatientsPage";
import {HomePage} from "./Pages/HomePage";
import {NoPage} from "./Pages/NoPage";
import Layout from "./Components/Layout";
import PredictPage from "./Pages/PredictPage";
import Navbar from "./Components/Navbar";
function App() {
    return (
            // @ts-ignore
      <BrowserRouter>
          <Navbar />
        <Routes>

            <Route  path="/" element={<HomePage/>}/>
            <Route  path="Home" element={<HomePage/>}/>
            <Route path="Predict" element={<PredictPage />} />
            <Route path="ExtraAtentionPatients" element={<ExtraAttentionPatientsPage />} />
            <Route path="*" element={<NoPage />} />
          
        </Routes>
      </BrowserRouter>
  );
}

export default App;
