# 📚 TechChallenge Grupo 4SOAT

Sistema de autoatendimento para fast-foods.

## 📽️ Video Youtube Arquitetura

https://youtu.be/KOwE_lIzVaw

![image](https://github.com/rof20004/TechChallenge/assets/67924745/9f358d7d-a9d8-4d7c-ba32-9aa6b8f889ed)

# Lambda de Autenticação 
https://github.com/kauanF7/lambda

Vídeo Explicativo: https://www.youtube.com/watch?v=W_S5j6gb9Ks

# Terraform RDS
https://github.com/kauanF7/rds-terraform

# Terraform EKS
https://github.com/kauanF7/eks-terraform

# Relacionamento Banco de Dados (MySql)
![image](https://github.com/rof20004/TechChallenge/assets/40708971/1d7f3ac9-aad6-4b6d-8272-b5328d933747)

Conforme o entregável 1 e 2, a escolha do banco de dados era individual por grupo.
Optamos por usar um banco de dados relacional (MySql), devido à familiaridade dos integrantes em utilizar essa tecnologia e pela necessidade dos relacionamentos que era solicitado. Além disso, o MySql é um banco de dados muito performático. 


## 🛳️ Como rodar no Kubernetes local

**Obs. 1: os comandos abaixo foram testados em ambientes unix-like. As vezes é necessário aguardar 1 ou 2 minutos para toda a infra do cluster ficar utilizável.**

```bash
  cd k8s
  kubectl apply --all -f .
```

**Obs. 2: O HPA necessita do metrics-server para funcionar corretamente, porém o metrics-server demora um pouco mais de 2 minutos para subir. Se for necessário realizar algum teste de carga é importante lembrar dessa informação.**

### Após tudo pronto, segue os endereços da API, Swagger e do Database:

- API: http://localhost:31000
- Swagger: http://localhost:31000/swagger/index.html
- Database hostname: localhost
- Database port: 32000

## 💡 Event Storm

O event storm do nosso projeto pode ser acessado pelo seguinte link:
- https://miro.com/app/board/uXjVMiZyAnE=/

## 💻 Como INICIAR a aplicação localmente?

Dentro da raíz do projeto execute um dos comandos abaixo.

- Máquinas Linux/Mac(terminal/shell): `./start-local-linux.sh`
- Máquinas Windows(via CMD ou PowerShell): `c:\TechChallenge\ start-local-windows.bat`

Após executar o passo acima, acesse o Swagger através: http://127.0.0.1:8080/swagger/index.html ou http://localhost:8080/swagger/index.html.

**Obs.:** caso o comando em máquinas linux ou mac não funcione, execute a seguinte instrução no terminal: `chmod +x start-local-linux.sh`

## 💻 Funcionalidades?
#### Cliente
###### Endpoint [POST] "/api/v1/cliente/{cpf}" : Cria um novo cliente.
###### Endpoint [GET] "/api/v1/cliente/{cpf}" : Consulta o cliente pelo CPF.
###### Endpoint [POST] "/api/v1/pedido/Create" : Cria um novo pedido com informação do cliente (query: informar id do Cliente | body: passar um array com o ID dos produtos. Ex: [1,2,3])
###### Endpoint [POST] "/api/v1/pedido/CreateWithoutCliente" : Cria um novo pedido sem informação do cliente (body: passar um array com o ID dos produtos. Ex: [1,2,3])
#
#### Pedido
###### Endpoint [GET] "/api/v1/pedido/GetAll" : Consulta todos os pedidos
###### Endpoint [GET] "/api/v1/pedido/Get" : Consulta o pedido específico através do ID do Pedido. 
###### Endpoint [PUT] "/api/v1/pedido/PutStatusPedido" : Atualiza o status do pedido Recebido = 1, Preparando = 2, Pronto = 3, Finalizado = 4
###### Endpoint [GET] "/api/v1/pedido/Get" : Consulta o status do pagamento do pedido. 
#
#
#### Produto
###### Endpoint [POST] "/api/v1/produto/Create" : Cria um produto.
###### Endpoint [GET] "/api/v1/produto/GetAll" : Consulta todos os produtos.
###### Endpoint [GET] "/api/v1/produto/Get" : Consulta o produto específico através do ID do Produto.
###### Endpoint [DELETE] "/api/v1/produto/Delete" : Deleta um produto.
###### Endpoint [POST] "/api/v1/produto/Alter" : Altera informações de um produto.

#
## 💻 Como PARAR a aplicação localmente?

`docker-compose down`

## 💻 Sugestão de Uso

- 1 - Cria alguns Produtos
- 2 - Criar um Cliente.
- 3 - Criar um Pedido (com as informações criadas na etapa 1 e 2.)
- 4 - Consultar as informações nos métodos GET.

## ✔️ Tecnologias utilizadas

- ``.Net 6``
- ``MySQL``
- ``Docker``

## 👨‍💻 Integrantes
Edgar Santos,
Kauan Falcão,
Leandro Carvalho,
Rodolfo Azevedo,
Marcel Leme

@2024
