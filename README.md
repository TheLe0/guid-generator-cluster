# Guid Generator

This is a simple .NET REST API application running on a local kubernetes cluster. To demonstrate how you can run your docker images locally.

## Configuration

To run this application you must have installed on your machine the following tools:

* [Docker](https://docs.docker.com/get-docker/)
* [Kubectl](https://kubernetes.io/releases/download/)
* [Kind](https://kind.sigs.k8s.io/docs/user/quick-start/#installation)

After everything installed, you just have to run the following commands:

>Note: Execute everything on the root of this project (the same folder as this README file).

1. Build the .NET REST API docker image(make sure docker is running on your machine):

```bash
docker build -t guid-api ./src/GuidGenerator.API
```

To check if the image was created just type:

```bash
docker images
```

And see if there's a image named ```guid-api```.

To run the container on Docker run:

```bash
docker run -it --rm -p 5000:80 --name my-guid-generator-container guid-api
```

2. Create the cluster:

```bash
kind create cluster
```
And type again the command ```docker images```, to see if the cluster was created. But, on this time, search for a ```kindest/node```image.

3. Load the docker image created before inside the cluster:

```bash
kind load docker-image guid-api
````

4. Apply the kubernetes policy to the cluster, for the cluster knows how to behave. 

```bash
kubectl apply -f kubernetes/manifest.yaml
```

This might take a while, to see when its read type the following:

To see if the cluster was deployed successfully:

```bash
kubectl get deploy
````
And this to see if the pods are running. A pod is an instance of your application (docker image created on this case).

```bash
kubectl get pods
```

If both shows ```ready```your application is ready to go. If not, and spent a significant time, may something is broken (must probably on the kubernetes manifest).

To see the log of the .NET application, type:

```bash
kubectl logs deploy/guid-api
```

5. You cannot access the application yet, because is pointing to a port on localhost inside the cluster. You must point to a port on the localhost of your machine:

```bash
kubectl port-forward service 3000:80
```

Now, if you access the ``http://localhost:3000/```, you application is running!.
