# minimal-api-csharp-todos
Simple api permettant la création, la suppression et l'update de todo, en C#

- - -

## Les endPoints :

rajoutez les paramètres d'url après votre local host dans votre navigateur après avoir exécuté le fichier program.cs du repo. Encore mieux si vous passez par postman !

#### En GET on retrouve : 
/getAll : permet d'obtenir la liste des todo en format json. A savoir qu'il y a nativement trois taches dans la liste des todo.

/getActives?IsActive=true : permet d'avoir toutes les taches actives

/getById/Id : affiche la tache attachée à l'id renseigné, par exemple /getById/2 retournera `{
        "id": 2,
        "title": "Acheter du pain",
        "isActive": true
    }`

#### En DELETE :

/delete/id : supprime la tache associée à l'id renseignée

#### En POST :

/todos : ajoute la tache que vous renseignerer dans le body sous cette forme : `{
        "title": "Acheter du blé",
        "isActive": true
    }`

#### En PUT :

/put/id : modifie la tache attachée à l'id renseigné, en renseignant la nouvelle tache sous cette forme :
`{
        "title": "Tache modifiée",
        "isActive": false
    }`

- - -

#### Points d’amélioration :

- Garder en mémoire les taches ajoutées
- Accepter d'autres formats que JSON pour les méthodes PUT et POST
- Connexion avec une vrai BDD
