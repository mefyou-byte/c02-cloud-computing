# TL;DR

Es wird ein Deployment mittels Local-Git angestrebt, dafür sind folgende Schritte erforderlich:

1. Ressourcen Gruppe anlegen
2. App Service Plan für die Ressourcen Gruppe anlegen (Free Tier)
3. Web App Ressource anlegen mit Local-Git-Deployment
4. IaC Dateien exportieren

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

# Azure Web App mittels Local-Git deployen

git remote add azure

# Azure IaC Dateien exportieren

**Ressourcen-Gruppe mit Parameter-Werten exportieren**
`az group export --name cc-group-1 --include-parameter-default-value > template.json`
