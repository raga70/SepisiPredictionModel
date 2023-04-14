# 

# **Sepsis Prediction AI Model**

This project aims to develop a model that can predict sepsis. Sepsis is a life-threatening condition caused by the body's response to an infection, and early recognition and timely intervention are essential to improve patient outcomes.

## **Domain Understanding**

Please refer to the **[Domain Understanding document](https://github.com/raga70/SepisiPredictionModel/blob/master/ReserchAndModelCreation/DomainUnderstanding.pdf)** for more information on the exploratory research, co-reflection with a fellow student, and interview with an expert.

## **Data Sourcing**

The dataset used for this project is provided by Johns Hopkins University. For more detailed information, please refer to the notebook of **[MAINnotebook](https://github.com/raga70/SepisiPredictionModel/blob/master/ReserchAndModelCreation/MAINmodelNotebook.pdf)**.

## **Analytical Approach**

This is a classification problem where we need to classify if the patient's parameters look like sepsis. The model was evaluated using various metrics, including accuracy, precision, and recall. The latest iteration, iteration 2.1, achieved good results with both recall and precision.

## **Possible Use Cases**

There are two possible use cases for this model:

- Use Case 1: The system is implemented as standalone, and medical professionals can enter patients' data to receive a prediction for the likelihood of sepsis diagnoses.
- Use Case 2: The system is integrated as part of the existing hospital infrastructure and automatically processes available patients' data.

For this project's demonstration, Use Case 1 will be developed.

## **End Product**

The end product consists of a REST API backend and a web application frontend. The backend has an endpoint **`/predict`**, which returns an immediate evaluation from the provided medical data and saves the record in the database. The endpoint **`/ExtraAttentionPatients`** displays today entered positive patients ordered by certainty.

The web application provides a simple interface for medical professionals to enter a new result and receive an instantaneous prediction. If the medical professional navigates to the ExtraAttentionPatients page, they will be presented with patients that might require a second look.

A small presentation of the finished product is available at **[Tome](https://tome.app/ragasworkspace/sepsis-predictor-3000-clgcdr0cg00pyap42l7fw5kd8)** 


## **How to Use**

This tool should only be used to give you a general tip about patients that might have been left unnoticed. It should not be used to determine a diagnosis; it can only point you in the right direction.
