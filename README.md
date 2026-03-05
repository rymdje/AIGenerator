# TP Machine Learning – Prédiction du CO2 des véhicules

Ce projet correspond au TP de Machine Learning réalisé en C# avec **ML.NET**.  
Le but est de partir d’un fichier CSV de véhicules, de nettoyer les données, puis d’entraîner un modèle capable de **prédire les émissions de CO2** d’un véhicule.

Le projet est séparé en plusieurs étapes pour bien comprendre chaque partie.

---

## 1. Nettoyage des données (TDTP1_1_CSVHelper)

Dans cette partie on utilise la bibliothèque **CsvHelper** pour lire le fichier CSV original.

Le but est de récupérer seulement les colonnes utiles :

- Puissance
- Poids à vide
- Conso mixte
- Energie
- CO2

Ensuite on génère un nouveau fichier :

`vehicules_output.csv`

Ce fichier est plus simple et sera utilisé pour l'entraînement du modèle.

---

## 2. Chargement des données (TDTP1_2_ML)

Dans cette étape on charge le fichier `vehicules_output.csv` avec **ML.NET**.

On utilise la fonction :

`LoadFromTextFile`

Cela permet de transformer les lignes du CSV en objets C# (`CarData`).

On affiche aussi quelques lignes pour vérifier que les données sont bien chargées.

---

## 3. Entraînement du modèle (TDTP1_3_ML)

Ensuite on crée un **pipeline de machine learning**.

Les étapes du pipeline :

1. Encodage de la colonne `Energie` avec **One-Hot Encoding**
2. Création du vecteur `Features`
3. Entraînement d'un modèle de régression (**FastTree**)

Le modèle est ensuite évalué avec deux métriques :

- **RMSE** (erreur moyenne)
- **R²** (qualité du modèle)

Ces valeurs permettent de voir si le modèle prédit correctement le CO2.

---

## 4. Prédiction (TDTP1_4_ML)

Dans la dernière étape on utilise le modèle pour faire une **prédiction**.

On crée un exemple de véhicule avec :

- Puissance
- Poids à vide
- Conso mixte
- Energie

Le programme affiche ensuite la **valeur de CO2 prédite**.

---

## Technologies utilisées

- C#
- .NET
- ML.NET
- CsvHelper

---

## Comment lancer le projet

1. Ouvrir la solution dans Visual Studio
2. Choisir le projet correspondant à l'étape (CSVHelper / ML / Train / Predict)
3. Lancer le projet

Chaque projet correspond à une étape du TP.
