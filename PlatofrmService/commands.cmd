docker build -t arsenisakhnik/pltofrmService
docker run -p 8080:80 -d arsenisakhnik/pltofrmservice

kubectl rollout restart deployment platforms-depl
