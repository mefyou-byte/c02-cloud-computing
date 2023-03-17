# Cloud Computing Gruppe 1

## Team

- Hade Mohamed
- Andreas Dreer
- Matiou Faltas
- Stephan Lanegger

# Deployment

Unter `doc/deployment.md` befindet sich eine Anleitung für das Deployment in Azure.

# Diagnostics

Azure Portal stellt Werkzeuge für die Diagnose von Problemen bereit siehe [Doku](https://learn.microsoft.com/en-us/azure/app-service/overview-diagnostics)

Das Diagnostic Interface bietet folgende Bereiche an:

1. Ask Genie
2. Risk Alerts
3. Troubleshooting categories
4. Popular troubleshooting tools

## Ask Genie

Ist ein Chat-basierter Bot, der grundlegende diagnostische Fragestellungen mittels aktuellen Fakten/Checks beantwortet bzgl. auch auf weiterführende Dokumente verweist:
![alt ask-genie](./doc/images/diagnostics/ask-genie.png)

## Risk Alerts

In diesem Bereich werden Check-Ergebnisse betreffend der Konfiguration der App angezeigt und Maßnahmen erläutert:
![alt risk-alerts-1](./doc/images/diagnostics/risk-alerts-1.png)
![alt risk-alerts-2](./doc/images/diagnostics/risk-alerts-2.png)

## Troubleshooting categories

Es gibt vier Kategorien für tiefgreifende Diagnosen:

- Availability and Performance
- Configuration and Management
- SSL and Domains
- Risk Assessments
- Navigator (Preview)
- Diagnostic Tools

Von hohem Interesse ist i. d. R. die Verfügbarkeit und Lasteffizienz der App. Für weitere Vertiefung wird an dieser Stelle auf die [Microsoft-Doku](https://learn.microsoft.com/en-us/azure/app-service/overview-diagnostics) verwiesen.

### Availability and Performance

Für die Überprüfung der Verfügbarkeit und Lasteffizienz stehen verschiedene Tools zur Verfügung, die folgendes ermöglichen:

- Identifikation von Downtime der App
- Identifikation von Latenzproblemen der App
- Analyse der CPU- oder Speicher-Nutzung
- Analyse ausgehender TCP-Verbindungen der App
- Analyse der HTTP 4xx Fehler
- Health-Checks
- u.v.m.


# Logging

Azure App Services erlauben klassische Logs auf unterschiedlichen Ebenen eines App Services mitzuschreiben: 

  * Application log
    * file system des app service
    * Azure storage blob
  * Web server logging (nur Windows als Plattform)
  * detailed error messages (nur Windows als Plattform)
  * failed request tracinga (nur Windows als Plattform)
  * Deployment logging


Zu finden sind diese Einstellungen im Bereich Monitoring - App Service Logs. 
Zu jedem Log kann das Loglevel, also wie detailliert die Logs aufgezeichnet werden, eingestellt werden:

  * disabled
  * error
  * warning
  * information
  * verbose

![alt Logging-Settings](.doc/images/logging/log-settings.jpg)

Unter _Log stream_ kann man im azure Portal die Application logs oder die Web Service logs in einer Konsole mitlesen. Alternativ können die Logs auch in der Cloud Shell mit dem folgenden Kommando verfolgen:

```CloudShell
az webapp log tail --name appname --resource-group myResourceGroup
```

![alt web-service-log](.doc/images/logging/webserver-log.jpg)

## Weitere Möglichkeiten 

Auch in den Diagnostics können Einstellungen getroffen werden, um diverse Logs anzuzeigen. 
Azure Monitor ist ein eigenes Azure service, das logs von unterschiedlichen Azure und on premise Ressourcen sammeln und aggregieren kann. 

Eine detaillierte Beschreibung findet sich in der [Microsoft Doku](https://learn.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs).


# Observability 
Observability in Azure ermöglicht die Überwachung der internen Zustände eines Systems durch das Sammeln und Analysieren von Daten aus verschiedenen Quellen. 
Mit anderen Worten, es geht darum, zu sehen, was innerhalb Ihres Systems zu jedem Zeitpunkt geschieht, auch wenn es sich über mehrere Umgebungen verteilt.

Azure bietet mehrere Tools und Services zur Unterstützung der Observability, darunter:

Azure Application Insights: Ein Dienst, der detaillierte Telemetrie- und Diagnosedaten zu Ihrer Anwendung bereitstellt, einschließlich 
Leistungsmetriken, Ausnahmeverfolgung und Anforderungsverfolgung.

Azure Log Analytics: Ein Dienst, mit dem Sie Log- und Leistungsdaten aus einer Vielzahl von Quellen, einschließlich Azure-Ressourcen und
Drittanbieteranwendungen, sammeln, analysieren und visualisieren können.

Azure Service Health: Ein Dienst, der aktuelle Informationen über den Zustand von Azure-Diensten in Ihrer Region bereitstellt.

Um die Observability in Azure aufrechtzuerhalten, sind einige bewährte Methoden zu beachten. Hierzu gehören die Implementierung
von Überwachungs- und Protokollierungsmechanismen in Anwendungen und Infrastruktur, die Verwendung von Diagnose- und Analysetools und die Einhaltung
bewährter Methoden für die Entwicklung und Bereitstellung von Anwendungen und Diensten.


Azure Monitor: Ein zentralisierter Überwachungsdienst, der Echtzeit-Sichtbarkeit in die 
Leistung und Gesundheit Ihrer Anwendungen und Infrastruktur bietet.

Hier ein Beispiel wie Azure Monitoring eingesetzt werden kann: 

1.) Azure Monitor über eine ressourcengruppe erstellen -> diese kann zum Beispiel eine VM oder Datenbank sein. In diesem Fall ist es eine Azure Cosmos DB.

Dadurch kann ein Monitoring über die CosmosDB erfolgen: 
![image](https://user-images.githubusercontent.com/74449850/225974841-fef121d4-766d-4027-91fc-9ae7c7aac35a.png)

Zudem können verschiedene Metriken ausgewählt werden: 
 ![image](https://user-images.githubusercontent.com/74449850/225974952-6076be83-aa2c-4875-bf22-e3189d605a57.png)

