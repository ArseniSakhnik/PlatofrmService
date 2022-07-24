kubectl apply -f platforms-depl.yaml
kubectl apply -f platforms-np-srv.yaml
kubectl get services
kubectl get deployments
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.3.0/deploy/static/provider/aws/deploy.yaml
kubectl get pods --namespace=ingress-nginx
kubectl delete all --all