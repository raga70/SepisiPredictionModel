import sklearn
import pandas
import seaborn
import numpy as np

from sklearn.preprocessing import StandardScaler
from sklearn import preprocessing
from sklearn.svm import SVC
from sklearn.metrics import accuracy_score, confusion_matrix

from Model.Patient import Patient
from Model.PredictionRequestDTO import PredictRequestDTO


def predict(patientRequestDTO: PredictRequestDTO) -> Patient:
    ## Load the data
    columns = ["ID", "PRG", "PL", "PR", "SK", "TS", "M11", "BD2", "Age","Insurance", "Sepssis"]
    df = pandas.read_csv("Balanced_Paitients_Files_Train.csv" , names=columns)
    
    ##scale the data
    from sklearn.preprocessing import StandardScaler
    df.drop(columns=["ID"], inplace=True)
    from sklearn import preprocessing
    encoder = preprocessing.LabelEncoder()
    df["Sepssis"] = encoder.fit_transform(df["Sepssis"])
    
    # Separate the target variable from the input features
    X = df.iloc[:,:-1]  # input features
    y = df.iloc[:, -1]  # target variable (sepsis)
    
    # Scale the input features only
    scaler = StandardScaler()
    scaler.fit(X)
    X_scaled = scaler.transform(X)
    
    # Combine the scaled input features and the target variable
    df_scaled = pandas.concat([pandas.DataFrame(X_scaled, columns=X.columns), y], axis=1)
    
    
    
    candidates = columns[1:-2]
    ##Removing the outliers
    
    z_scores = np.abs((df[candidates] - df[candidates].mean()) / df[candidates].std())
    threshold = 5
    df_cleaned = df_scaled[(z_scores < threshold).all(axis=1)]
    
    
    features = ["PL", "Age", "M11", "PR", "TS"]
    target = "Sepssis"
    X = df_cleaned[features]
    y = df_cleaned[target]
    
    
    from sklearn.model_selection import train_test_split
    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2)
    print("There are in total", len(X), "observations, of which", len(X_train), "are now in the train set, and", len(X_test), "in the test set.")
    
    
    from sklearn.linear_model import LogisticRegression
    from sklearn.metrics import accuracy_score, classification_report
    
    target_names = [encoder.classes_[0], encoder.classes_[1]]
    # Train and evaluate model with Logistic Regression
    clf = LogisticRegression(C=1.0, class_weight=None, penalty='l2', max_iter=100,solver='lbfgs')
    clf.fit(X_train, y_train)
    

    X_new = [[patientRequestDTO.PL, patientRequestDTO.Age, patientRequestDTO.M11, patientRequestDTO.PR, patientRequestDTO.TS]]
    sepsisChance = clf.predict_proba(X_new)[0][1]
    sepsisPrediction = clf.predict(X_new)[0]
    
    #DEBUG
    y_pred = clf.predict(X_test)
    acc = accuracy_score(y_test, y_pred)
    print(f"predicted patient {patientRequestDTO.patientID} has a {sepsisChance} chance of having sepsis and the model predicted {sepsisPrediction}")
    print("Accuracy:", acc)
    print(classification_report(y_test, y_pred, target_names=target_names))
    
    
    
    
    
    return Patient(patientRequestDTO=patientRequestDTO, sepsisPrediction=sepsisPrediction, certainty=sepsisChance)
    