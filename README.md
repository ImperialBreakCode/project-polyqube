# PolyQube

This README is still under construction 🚧🚧🚧 

## Install backend on Docker (production)

1. Go to `src/Backend` and run the following Docker Compose command:
    ```bash
    docker-compose -f docker-compose.yml -f docker-compose.prod.yml --env-file .env up -d
    ```

2. Set up a proxy for the asset storage
    - Open `localhost:81` in your browser
    - Log in with the following credentials:
        - Email: `admin@example.com` 
        - Password: `changeme`
    
        Immediately after logging in with this default user you will be asked to modify your details and change your password.

    - Navigate to **Hosts > Proxy Hosts**, then add new proxy host with the following settings:    
        - Domain name `localhost`
        - Scheme: `http`
        - Forward hostname: `minio`
        - Forward port: `9000`
        - In the advanced tab, add the following custom Nginx configuration:
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