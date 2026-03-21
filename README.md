# PolyQube

This README is still under construction 🚧🚧🚧

## Install backend on Docker (production)

1. Go to `src/Backend`

2. Run the following command to create env file from the example (you only need to add ethereal email smtp creds)

    ```bash
    cp env.example.txt .env
    ```

3. Run the following Docker Compose command to install and start the backend APIs:

    ```bash
    docker-compose -f docker-compose.yml -f docker-compose.prod.yml --env-file .env up -d
    ```

4. Set up a proxy for the asset storage
    - Open `localhost:81` in your browser
    - Create local nginx proxy account and login

    - Navigate to **Hosts > Proxy Hosts**, then add new proxy host with the following settings:
        - Domain name `localhost`
        - Scheme: `http`
        - Forward hostname: `minio`
        - Forward port: `9000`
        - In the advanced tab (the settings icon), add the following custom Nginx configuration:
            ```nginx
            location / {
                proxy_set_header host "minio:9000";
                proxy_pass $forward_scheme://$server:$port$request_uri;
            }
            ```
    - Click **Save**. The backend installation is complete.

## Superuser credentials

- <b>username:</b> `root`
- <b>password:</b> `root`
