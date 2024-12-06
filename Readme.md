
# **MS - Travail sur les fichiers**

## 🖋️ Description
Ce programme est une application qui permet d’effectuer différentes opérations sur des fichiers. Il a été conçu dans le cadre d'un projet éducatif et est destiné à montrer des fonctionnalités comme la manipulation de fichiers, la gestion des erreurs, et l'affichage de résultats en fonction des données d’entrée

## ✅ **Prérequis**
Pour exécuter ce programme, vous devez disposer des éléments suivants :
- Un système d'exploitation Windows compatible avec le fichier `.exe` fourni.
- Les droits nécessaires pour exécuter des programmes téléchargés.
- Les fichiers à traiter doivent être placés dans un dossier accessible au programme.

## ⚙️ **Installation**
1. Clonez ou téléchargez le projet depuis le dépôt GitHub :  
   [https://github.com/quamilou/MS-Travail-sur-les-fichiers](https://github.com/quamilou/MS-Travail-sur-les-fichiers)
2. Naviguez jusqu'au dossier `bin` où se trouve le fichier exécutable `MS_Travail_Fichiers.exe`.

## ▶️ **Utilisation**
1. **Exécution du programme** :
   - Double-cliquez sur le fichier `MS_Travail_Fichiers.exe` dans le dossier `bin`.
   - Une interface en ligne de commande s'ouvrira pour interagir avec le programme.

2. **Options disponibles** :
   - Le programme est interactif et vous guidera à travers les différentes fonctionnalités disponibles. Pour plus de détails sur chaque fonctionnalité, consultez l'annexe ci-dessous.

3. **Résultats** :
   - Les résultats des opérations seront affichés directement dans le terminal ou enregistrés dans des fichiers de sortie, selon les options choisies.

---

### Diagramme de fonctionnement du programme
```
+---------------------------+
|       Programme           |
|         Principal         |
+---------------------------+
            |
            | Boucle de Menu
            v
+---------------------------+
|        Affichage          |
|         du Menu           |
+---------------------------+
            |
            |--- Choix 1: Saisir un nouveau client ------------------> SaisirNouveauClient()
            |
            |--- Choix 2: Afficher un client -----------------------> AfficherClient()
            |
            |--- Choix 3: Afficher tous les clients ----------------> AfficherTousLesClients()
            |
            |--- Choix 4: Afficher le nombre de clients ------------> AfficherNombreClients()
            |
            |--- Choix 5: Modifier un client -----------------------> ModifierClient()
            |
            |--- Choix 6: Supprimer une fiche ----------------------> SupprimerFiche()
            |
            |--- Choix 7: Récupérer une fiche supprimée -----------> RecupererFiche()
            |
            |--- Choix 8: Afficher les fiches supprimées ----------> AfficherFichesSupprimees()
            |
            |--- Choix 9: Compresser le fichier --------------------> CompresserFichier()
            |
            |--- Choix 10: Quitter ---------------------------------> Fin du Programme
```

## 📖 **Annexe : Fonctionnalités du projet**

### 1️⃣ **Saisir un nouveau client**
- Permet d'ajouter une nouvelle fiche client en saisissant des informations telles que le nom, le prénom, l'adresse, etc.
- **Détail** : Les données saisies sont enregistrées dans un fichier binaire nommé `clients.bin` pour une gestion efficace.

### 2️⃣ **Afficher un client**
- Affiche les informations d'un client spécifique en recherchant par nom ou identifiant.
- **Détail** : Le programme lit le fichier `clients.bin` et affiche les informations correspondantes.

### 3️⃣ **Afficher tous les clients**
- Liste toutes les fiches clients enregistrées.
- **Détail** : Parcourt le fichier `clients.bin` et affiche toutes les entrées.

### 4️⃣ **Afficher le nombre de clients**
- Indique le nombre total de clients enregistrés.
- **Détail** : Compte les entrées dans le fichier `clients.bin`.

### 5️⃣ **Modifier un client**
- Permet de mettre à jour les informations d'une fiche client existante.
- **Détail** : Après identification de la fiche à modifier, le programme met à jour les données dans le fichier `clients.bin`.

### 6️⃣ **Supprimer une fiche**
- Supprime une fiche client du fichier principal.
- **Détail** : La fiche est déplacée du fichier `clients.bin` vers un fichier `clients_deleted.bin` pour une éventuelle récupération future.

### 7️⃣ **Récupérer une fiche supprimée**
- Restaure une fiche client précédemment supprimée.
- **Détail** : La fiche est déplacée de `clients_deleted.bin` vers `clients.bin`.

### 8️⃣ **Afficher les fiches supprimées**
- Liste toutes les fiches clients qui ont été supprimées.
- **Détail** : Parcourt le fichier `clients_deleted.bin` et affiche les entrées.

### 9️⃣ **Rechercher un client par critère**
- Permet de rechercher des clients en fonction de critères spécifiques (par exemple, ville, code postal).
- **Détail** : Effectue une recherche dans `clients.bin` en fonction des critères fournis.

### 🔟 **Exporter les données clients**
- Exporte les données des clients dans un format spécifique (par exemple, CSV) pour une utilisation externe.
- **Détail** : Génère un fichier `clients_export.csv` contenant les données des clients.

