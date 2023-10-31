docker-compose up -d --build
echo "Waiting for API to start to run EF migrations..."
sleep 10
echo "Running EF migrations..."
docker container exec -it techchallenge-api1-1 bash -c /app/efbundle
echo "Done running EF migrations."