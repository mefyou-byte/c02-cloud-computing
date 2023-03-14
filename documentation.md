# TL;DR
1. Ressourcen Gruppe anlegen
2. App Service Plan für die Ressourcen Gruppe anlegen (Free Tier)
3. Web App Ressource anlegen
4. IaC Dateien

# Azure Ressourcen Gruppe anlegen

```shell
az group create --name cc-group-1 --location westeurope --subscription "<subscription-id>"
```


# Azure App Service Plan erstellen

```
az appservice plan create --name ApplicationPlan --sku F1 --resource-group cc-group-1

```
# Azure Web App anlegen
`az webapp create --resource-group cc-group-1 --plan ApplicationPlan --name meal-db --runtime "dotnet:6" --deployment-local-git`


# Azure Web App deployen
az webapp deployment source config-local-git --name meal-db --resource-group cc-group-1

{
  "url": <git-url>
}

`git remote add azure <git-url>`
`git push azure master`

# Azure IaC Dateien exportieren
**Ressourcen-Gruppe exportieren**
`az group export --name cc-group-1 --include-parameter-default-value > template.json`


