# hello-distributed-world
Simple .NET application running on a kubernetes cluster

## Configuration

To run the application you must have the following:

* Docker
* Kubectl
* Kind

After everything installed, run the following commands:

```bash
docker build -t guid-api ./src/GuidGenerator.API
kind create cluster
kind load docker-image guid-api
kubectl apply -f kubernetes/manifest.yaml
kubectl get deploy
kubectl get pods
kubectl logs deploy/website
kubectl port-forward service 3000:80
```