Traccia progetto n.1

Realizzazione di una web api che permetta la gestione di un catalogo di una libreria.

Esecuzione Progetto

Creazione Database
Creare il database utilizzando il dump.sql.

Credenziali del Database 'enterprise':

user : paradigmi
password: enterprise

Esecuzione
Eseguire il progetto UnicamParadigmi.Web in cui è situato Swagger.

Registrazione e Login
Registrarsi utilizzando una mail non utilizzata e una password che deve essere lunga almeno 6 caratteri, contenere almeno un carattere maiuscolo, un carattere minuscolo, un numero e un carattere speciale.

Per il Login: inserire email e password e si otterà il token jwt che è necessario per effettuare tutte le chiamate http.

Chiamate

Libro:

CreateBook : chiamata per l'inserimento di un libro;
UploadBook : chiamata per la modifica di un libro;
DeleteBook : chiamata per l'eliminazione di un libro;
SearchBook : Ricerca di un libro per editore, nome, categoria e data di pubblicazione;

La ricerca paginerà i risultati in base ai parametri passanti nella chiamata, verranno visualizzati i libri e il numero delle pagine.

Categorie:

CreateCategory : chiamata per l'inserimento di una categoria;
DeleteCategory : chiamata per la rimozione di una categoria;

Utente:
CreateUser : chiamata per creare un nuovo utente senza autenticazione;
