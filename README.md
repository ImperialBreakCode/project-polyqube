# PolyQube

This README is still under construction 🚧🚧🚧

## Install Backend on Docker (production)

1. Go to `src/Backend`

2. Create your .env file from the provided example. The only values you need to supply are the Ethereal Email SMTP credentials:

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

### Frontend Installation (Production)

#### Prerequisites

Ensure you have the correct **Node.js** and **pnpm** versions installed.

**Node.js** — use [nvm](https://github.com/nvm-sh/nvm) to install and switch to the project version:

```bash
nvm install 24.11.1
nvm use 24.11.1
```

**pnpm** — install the exact version specified in `package.json`:

```bash
npm install -g pnpm@10.32.1
```

---

#### Install Dependencies

Navigate to the `src/frontend` directory and install dependencies using the lockfile:

```bash
cd src/frontend
pnpm install --frozen-lockfile
```

---

#### Environment Setup

Copy the example env file for the web app:

```bash
cp apps/web/env.example.txt apps/web/.env
```

---

### Build

From the `frontend` directory, run the production build:

```bash
pnpm run build
```

---

### Start

**Main website** (`apps/web`):

```bash
cd apps/web
npm start
```

**Admin panel** (`apps/admin`):

```bash
cd apps/admin
npm start
```

## Superuser credentials

- <b>username:</b> `root`
- <b>password:</b> `root`
