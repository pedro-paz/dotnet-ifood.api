# Install EF

```
dotnet tool install --global dotnet-ef
```

# Add Migrations

```
dotnet-ef migrations add <migration-name>
```

# Apply Migration

```
dotnet ef database update
```

# Build Docker Image

```
sudo docker build -t deep/wefood.api:1 .
```

# Run Docker Image

```
sudo docker run -p 8080:3000 deep/wefood.api:1
```
