--
-- PostgreSQL database dump
--

-- Dumped from database version 15.5
-- Dumped by pg_dump version 15.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: Clientes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Clientes" VALUES (2, 'Ana Paula Silva', 'ana.silva@hotmail.com', '21976543210', 'CPF', '087.932.486-03', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:23.444176-03', 1);
INSERT INTO public."Clientes" VALUES (3, 'Roberto Alves Souza', 'roberto.souza@yahoo.com.br', '31965432109', 'CPF', '412.375.198-05', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:23.903385-03', 1);
INSERT INTO public."Clientes" VALUES (4, 'Fernanda Costa Lima', 'fernanda.lima@gmail.com', '41954321098', 'CPF', '748.519.263-04', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:24.357104-03', 1);
INSERT INTO public."Clientes" VALUES (5, 'Marcos Antonio Oliveira', 'marcos.oliveira@outlook.com', '51943210987', 'CPF', '603.456.872-04', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:24.767256-03', 1);
INSERT INTO public."Clientes" VALUES (6, 'Patricia Moreira Santos', 'patricia.santos@gmail.com', '61932109876', 'CPF', '385.694.127-05', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:25.202284-03', 1);
INSERT INTO public."Clientes" VALUES (7, 'Lucas Henrique Pereira', 'lucas.pereira@gmail.com', '71921098765', 'CPF', '274.316.598-07', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:25.649348-03', 1);
INSERT INTO public."Clientes" VALUES (8, 'Juliana Rodrigues Melo', 'juliana.melo@hotmail.com', '81910987654', 'CPF', '819.423.657-09', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:26.062327-03', 1);
INSERT INTO public."Clientes" VALUES (9, 'Pedro Henrique Carvalho', 'pedro.carvalho@gmail.com', '85999887766', 'CPF', '502.789.346-05', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:26.466067-03', 1);
INSERT INTO public."Clientes" VALUES (10, 'Camila Nascimento Rocha', 'camila.rocha@gmail.com', '92988776655', 'CPF', '941.253.768-07', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:26.968549-03', 1);
INSERT INTO public."Clientes" VALUES (11, 'Tech Solutions Ltda', 'contato@techsolutions.com.br', '1133445566', 'CNPJ', '12.345.678/0001-90', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:27.425683-03', 1);
INSERT INTO public."Clientes" VALUES (12, 'Comercial Norte EIRELI', 'compras@comercialnorte.com.br', '9233445566', 'CNPJ', '23.456.789/0001-01', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:28.270271-03', 1);
INSERT INTO public."Clientes" VALUES (13, 'Digital Store SA', 'vendas@digitalstore.com.br', '1144556677', 'CNPJ', '34.567.890/0001-15', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:28.778144-03', 1);
INSERT INTO public."Clientes" VALUES (14, 'Andreia Cristina Pinto', 'andreia.pinto@gmail.com', '47977665544', 'CPF', '157.842.936-06', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:29.216389-03', 1);
INSERT INTO public."Clientes" VALUES (15, 'Diego Martins Barbosa', 'diego.barbosa@outlook.com', '54966554433', 'CPF', '683.024.195-08', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:29.614098-03', 1);
INSERT INTO public."Clientes" VALUES (16, 'Renata Freitas Cunha', 'renata.cunha@yahoo.com.br', '62955443322', 'CPF', '329.567.814-06', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:30.037164-03', 1);
INSERT INTO public."Clientes" VALUES (17, 'Thiago Lopes Azevedo', 'thiago.azevedo@gmail.com', '69944332211', 'CPF', '756.184.329-05', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:30.374387-03', 1);
INSERT INTO public."Clientes" VALUES (18, 'Simone Castro Vieira', 'simone.vieira@gmail.com', '73933221100', 'CPF', '218.743.965-07', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:30.765571-03', 1);
INSERT INTO public."Clientes" VALUES (19, 'Eduardo Gomes Teixeira', 'eduardo.teixeira@hotmail.com', '75922110099', 'CPF', '894.362.571-08', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:31.121124-03', 1);
INSERT INTO public."Clientes" VALUES (20, 'Vanessa Ribeiro Fonseca', 'vanessa.fonseca@gmail.com', '79911009988', 'CPF', '437.619.285-06', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:31.476638-03', 1);
INSERT INTO public."Clientes" VALUES (21, 'InfoPrime Distribuidora Ltda', 'info@infoprime.com.br', '1155667788', 'CNPJ', '45.678.901/0001-24', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:31.817436-03', 1);
INSERT INTO public."Clientes" VALUES (22, 'Mega Eletro Comercio ME', 'contato@megaeletro.com.br', '4155667788', 'CNPJ', '56.789.012/0001-35', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:32.181138-03', 1);
INSERT INTO public."Clientes" VALUES (23, 'Bruno Henrique Dias', 'bruno.dias@gmail.com', '83899887766', 'CPF', '561.297.384-07', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:32.543546-03', 1);
INSERT INTO public."Clientes" VALUES (24, 'Larissa Oliveira Campos', 'larissa.campos@gmail.com', '98898776655', 'CPF', '193.748.526-04', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:32.955928-03', 1);
INSERT INTO public."Clientes" VALUES (25, 'Fabio Augusto Monteiro', 'fabio.monteiro@outlook.com', '96897665544', 'CPF', '724.863.159-03', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:33.323919-03', 1);
INSERT INTO public."Clientes" VALUES (26, 'Cristina Santos Araujo', 'cristina.araujo@gmail.com', '88896554433', 'CPF', '349.175.862-08', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:33.679669-03', 1);
INSERT INTO public."Clientes" VALUES (27, 'Rafael Souza Cardoso', 'rafael.cardoso@gmail.com', '91895443322', 'CPF', '587.342.916-04', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:34.067392-03', 1);
INSERT INTO public."Clientes" VALUES (28, 'Inovação Tech EIRELI', 'comercial@inovacaotech.com.br', '1166778899', 'CNPJ', '67.890.123/0001-40', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:34.413602-03', 1);
INSERT INTO public."Clientes" VALUES (29, 'Aline Ferreira Monteiro', 'aline.monteiro@hotmail.com', '11984563721', 'CPF', '246.893.715-09', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:34.745903-03', 1);
INSERT INTO public."Clientes" VALUES (30, 'Rodrigo Nunes Peixoto', 'rodrigo.peixoto@gmail.com', '21973652810', 'CPF', '613.587.249-00', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 'agent_clientes', '2026-03-27 21:32:35.149717-03', 1);
INSERT INTO public."Clientes" VALUES (1, 'Carlos Eduardo Ferreira', 'carlos.ferreira@gmail.com', '11987654321', 'CPF', '529.982.247-25', 'vvV+x/U6bUC+tkCngKY5yDvCmsipgW8fxsXG3Nk8RyE=', 'agent_clientes', '2026-03-27 21:32:22.936361-03', 1);


--
-- Data for Name: Enderecos; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Enderecos" VALUES (1, 1, 'Residencial', 'Rua das Flores', '142', 'Apto 31', 'Moema', 'São Paulo', 'SP', 'agent_clientes', '2026-03-27 21:33:00.816085-03', 1);
INSERT INTO public."Enderecos" VALUES (2, 2, 'Residencial', 'Av. Copacabana', '875', 'Apto 502', 'Copacabana', 'Rio de Janeiro', 'RJ', 'agent_clientes', '2026-03-27 21:33:01.273845-03', 1);
INSERT INTO public."Enderecos" VALUES (3, 3, 'Residencial', 'Rua Pernambuco', '320', '', 'Funcionários', 'Belo Horizonte', 'MG', 'agent_clientes', '2026-03-27 21:33:01.687482-03', 1);
INSERT INTO public."Enderecos" VALUES (4, 4, 'Residencial', 'Rua XV de Novembro', '1450', 'Casa 2', 'Centro', 'Curitiba', 'PR', 'agent_clientes', '2026-03-27 21:33:02.147316-03', 1);
INSERT INTO public."Enderecos" VALUES (5, 5, 'Residencial', 'Av. Ipiranga', '2300', 'Apto 801', 'Azenha', 'Porto Alegre', 'RS', 'agent_clientes', '2026-03-27 21:33:02.538617-03', 1);
INSERT INTO public."Enderecos" VALUES (6, 6, 'Residencial', 'SQN 308 Bloco A', '12', 'Apto 204', 'Asa Norte', 'Brasília', 'DF', 'agent_clientes', '2026-03-27 21:33:02.973779-03', 1);
INSERT INTO public."Enderecos" VALUES (7, 7, 'Residencial', 'Av. Sete de Setembro', '4567', '', 'Vitória', 'Salvador', 'BA', 'agent_clientes', '2026-03-27 21:33:03.383997-03', 1);
INSERT INTO public."Enderecos" VALUES (8, 8, 'Residencial', 'Rua da Aurora', '210', 'Apto 105', 'Boa Vista', 'Recife', 'PE', 'agent_clientes', '2026-03-27 21:33:03.821809-03', 1);
INSERT INTO public."Enderecos" VALUES (9, 9, 'Residencial', 'Av. Washington Soares', '3301', 'Casa', 'Edson Queiroz', 'Fortaleza', 'CE', 'agent_clientes', '2026-03-27 21:33:04.234729-03', 1);
INSERT INTO public."Enderecos" VALUES (10, 10, 'Residencial', 'Av. Djalma Batista', '1155', 'Apto 303', 'Chapada', 'Manaus', 'AM', 'agent_clientes', '2026-03-27 21:33:04.686826-03', 1);
INSERT INTO public."Enderecos" VALUES (11, 11, 'Comercial', 'Av. Paulista', '1811', 'Sala 1204', 'Bela Vista', 'São Paulo', 'SP', 'agent_clientes', '2026-03-27 21:33:05.14153-03', 1);
INSERT INTO public."Enderecos" VALUES (12, 12, 'Comercial', 'Av. Nazaré', '332', 'Sala 5', 'Nazaré', 'Belém', 'PA', 'agent_clientes', '2026-03-27 21:33:05.670689-03', 1);
INSERT INTO public."Enderecos" VALUES (13, 13, 'Comercial', 'Rua Felipe Schmidt', '700', 'Sala 301', 'Centro', 'Florianópolis', 'SC', 'agent_clientes', '2026-03-27 21:33:06.12085-03', 1);
INSERT INTO public."Enderecos" VALUES (14, 14, 'Residencial', 'Rua Blumenau', '88', '', 'América', 'Joinville', 'SC', 'agent_clientes', '2026-03-27 21:33:06.534052-03', 1);
INSERT INTO public."Enderecos" VALUES (15, 15, 'Residencial', 'Rua Andrade Neves', '540', 'Apto 42', 'Centro', 'Pelotas', 'RS', 'agent_clientes', '2026-03-27 21:33:06.932237-03', 1);
INSERT INTO public."Enderecos" VALUES (16, 16, 'Residencial', 'Av. T-3', '1847', 'Apto 201', 'Setor Bueno', 'Goiânia', 'GO', 'agent_clientes', '2026-03-27 21:33:37.838189-03', 1);
INSERT INTO public."Enderecos" VALUES (17, 17, 'Residencial', 'Rua Almirante Barroso', '2230', '', 'Olaria', 'Porto Velho', 'RO', 'agent_clientes', '2026-03-27 21:33:38.259619-03', 1);
INSERT INTO public."Enderecos" VALUES (18, 18, 'Residencial', 'Av. ACM', '556', 'Casa', 'Tancredo Neves', 'Salvador', 'BA', 'agent_clientes', '2026-03-27 21:33:38.671383-03', 1);
INSERT INTO public."Enderecos" VALUES (19, 19, 'Residencial', 'Rua Padre Feijó', '190', 'Apto 12', 'Canela', 'Salvador', 'BA', 'agent_clientes', '2026-03-27 21:33:39.10419-03', 1);
INSERT INTO public."Enderecos" VALUES (20, 20, 'Residencial', 'Rua Itabaianinha', '730', '', 'Centro', 'Aracaju', 'SE', 'agent_clientes', '2026-03-27 21:33:39.522611-03', 1);
INSERT INTO public."Enderecos" VALUES (21, 21, 'Comercial', 'Av. Brigadeiro Faria Lima', '3144', 'Sala 72', 'Itaim Bibi', 'São Paulo', 'SP', 'agent_clientes', '2026-03-27 21:33:40.010334-03', 1);
INSERT INTO public."Enderecos" VALUES (22, 22, 'Comercial', 'Rua Marechal Deodoro', '500', 'Loja 3', 'Centro', 'Curitiba', 'PR', 'agent_clientes', '2026-03-27 21:33:40.482685-03', 1);
INSERT INTO public."Enderecos" VALUES (23, 23, 'Residencial', 'Av. Epitácio Pessoa', '1420', 'Apto 301', 'Tambaú', 'João Pessoa', 'PB', 'agent_clientes', '2026-03-27 21:33:40.908368-03', 1);
INSERT INTO public."Enderecos" VALUES (24, 24, 'Residencial', 'Av. Jerônimo de Albuquerque', '880', '', 'Calhau', 'São Luís', 'MA', 'agent_clientes', '2026-03-27 21:33:41.329663-03', 1);
INSERT INTO public."Enderecos" VALUES (25, 25, 'Residencial', 'Rua Benjamin Constant', '321', '', 'Centro', 'Rio Branco', 'AC', 'agent_clientes', '2026-03-27 21:33:41.803198-03', 1);
INSERT INTO public."Enderecos" VALUES (26, 26, 'Residencial', 'Av. CPA', '2100', 'Apto 504', 'CPA', 'Cuiabá', 'MT', 'agent_clientes', '2026-03-27 21:33:42.236342-03', 1);
INSERT INTO public."Enderecos" VALUES (27, 27, 'Residencial', 'Av. Nossa Senhora da Penha', '2050', '', 'Santa Luíza', 'Vitória', 'ES', 'agent_clientes', '2026-03-27 21:33:42.807416-03', 1);
INSERT INTO public."Enderecos" VALUES (28, 28, 'Comercial', 'Rua do Ouvidor', '62', 'Sala 801', 'Centro', 'Rio de Janeiro', 'RJ', 'agent_clientes', '2026-03-27 21:33:43.243573-03', 1);
INSERT INTO public."Enderecos" VALUES (29, 29, 'Residencial', 'Rua Augusta', '2345', 'Apto 71', 'Consolação', 'São Paulo', 'SP', 'agent_clientes', '2026-03-27 21:33:43.669539-03', 1);
INSERT INTO public."Enderecos" VALUES (30, 30, 'Residencial', 'Rua Visconde de Pirajá', '540', 'Apto 201', 'Ipanema', 'Rio de Janeiro', 'RJ', 'agent_clientes', '2026-03-27 21:33:44.076546-03', 1);


--
-- Data for Name: Logs; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Logs" VALUES (1, 'Cliente', '{"id":1,"campo":"Senha","valor":"***"}', '{"id":1,"campo":"Senha","valor":"***"}', 'agent_clientes', '2026-03-27 22:15:37.841884-03');


--
-- Data for Name: Pedidos; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Pedidos" VALUES (1, 1, 1, 9499.00, 5.00, 9494.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:35:31.087895-03', 1);
INSERT INTO public."Pedidos" VALUES (2, 1, 37, 279.00, 0.00, 279.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:04.960417-03', 1);
INSERT INTO public."Pedidos" VALUES (3, 1, 69, 349.00, 3.00, 346.00, 1, 'DebitoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:05.643504-03', 1);
INSERT INTO public."Pedidos" VALUES (4, 2, 11, 4599.00, 8.00, 4591.00, 1, 'CreditoParcelado', 6, 'agent_clientes', '2026-03-27 21:36:06.196121-03', 1);
INSERT INTO public."Pedidos" VALUES (5, 2, 45, 199.00, 0.00, 199.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:06.93952-03', 1);
INSERT INTO public."Pedidos" VALUES (6, 2, 111, 399.00, 5.00, 394.00, 1, 'BoletoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:07.549593-03', 1);
INSERT INTO public."Pedidos" VALUES (7, 3, 21, 3299.00, 10.00, 3289.00, 1, 'CreditoParcelado', 8, 'agent_clientes', '2026-03-27 21:36:08.108888-03', 1);
INSERT INTO public."Pedidos" VALUES (8, 3, 53, 599.00, 0.00, 599.00, 1, 'CreditoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:08.758555-03', 1);
INSERT INTO public."Pedidos" VALUES (9, 4, 29, 1299.00, 7.00, 1292.00, 1, 'CreditoParcelado', 4, 'agent_clientes', '2026-03-27 21:36:09.340586-03', 1);
INSERT INTO public."Pedidos" VALUES (10, 4, 77, 219.00, 0.00, 219.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:09.991614-03', 1);
INSERT INTO public."Pedidos" VALUES (11, 4, 61, 1499.00, 5.00, 1494.00, 1, 'BoletoParcelado', 6, 'agent_clientes', '2026-03-27 21:36:10.613748-03', 1);
INSERT INTO public."Pedidos" VALUES (12, 5, 85, 2799.00, 0.00, 2799.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:36:11.092942-03', 1);
INSERT INTO public."Pedidos" VALUES (13, 5, 93, 1899.00, 3.00, 1896.00, 1, 'CreditoParcelado', 3, 'agent_clientes', '2026-03-27 21:36:11.63906-03', 1);
INSERT INTO public."Pedidos" VALUES (14, 6, 2, 8799.00, 10.00, 8789.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:36:12.101774-03', 1);
INSERT INTO public."Pedidos" VALUES (15, 6, 101, 1299.00, 0.00, 1299.00, 1, 'BoletoParcelado', 4, 'agent_clientes', '2026-03-27 21:36:12.64818-03', 1);
INSERT INTO public."Pedidos" VALUES (16, 6, 45, 199.00, 5.00, 194.00, 1, 'DebitoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:13.168128-03', 1);
INSERT INTO public."Pedidos" VALUES (17, 7, 12, 7899.00, 8.00, 7891.00, 1, 'CreditoParcelado', 8, 'agent_clientes', '2026-03-27 21:36:13.626419-03', 1);
INSERT INTO public."Pedidos" VALUES (18, 7, 103, 799.00, 0.00, 799.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:14.134083-03', 1);
INSERT INTO public."Pedidos" VALUES (19, 8, 22, 2199.00, 5.00, 2194.00, 1, 'CreditoParcelado', 6, 'agent_clientes', '2026-03-27 21:36:14.607352-03', 1);
INSERT INTO public."Pedidos" VALUES (20, 8, 86, 3299.00, 0.00, 3299.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:36:15.135626-03', 1);
INSERT INTO public."Pedidos" VALUES (21, 8, 112, 699.00, 3.00, 696.00, 1, 'PixParcelado', 3, 'agent_clientes', '2026-03-27 21:36:15.600855-03', 1);
INSERT INTO public."Pedidos" VALUES (22, 9, 30, 799.00, 0.00, 799.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:16.085552-03', 1);
INSERT INTO public."Pedidos" VALUES (23, 9, 78, 299.00, 5.00, 294.00, 1, 'BoletoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:16.63512-03', 1);
INSERT INTO public."Pedidos" VALUES (24, 10, 3, 5499.00, 10.00, 5489.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:36:17.192678-03', 1);
INSERT INTO public."Pedidos" VALUES (25, 10, 62, 3299.00, 0.00, 3299.00, 1, 'CreditoParcelado', 5, 'agent_clientes', '2026-03-27 21:36:17.726005-03', 1);
INSERT INTO public."Pedidos" VALUES (26, 10, 38, 349.00, 7.00, 342.00, 1, 'DebitoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:18.184899-03', 1);
INSERT INTO public."Pedidos" VALUES (27, 11, 87, 4499.00, 10.00, 4489.00, 1, 'BoletoParcelado', 12, 'agent_clientes', '2026-03-27 21:36:18.670298-03', 1);
INSERT INTO public."Pedidos" VALUES (28, 11, 94, 1299.00, 5.00, 1294.00, 1, 'BoletoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:19.154546-03', 1);
INSERT INTO public."Pedidos" VALUES (29, 12, 13, 8999.00, 10.00, 8989.00, 1, 'BoletoParcelado', 12, 'agent_clientes', '2026-03-27 21:36:19.659832-03', 1);
INSERT INTO public."Pedidos" VALUES (30, 12, 88, 5999.00, 8.00, 5991.00, 1, 'CreditoParcelado', 10, 'agent_clientes', '2026-03-27 21:36:20.139345-03', 1);
INSERT INTO public."Pedidos" VALUES (31, 12, 104, 1799.00, 0.00, 1799.00, 1, 'BoletoParcelado', 6, 'agent_clientes', '2026-03-27 21:36:20.625594-03', 1);
INSERT INTO public."Pedidos" VALUES (32, 13, 14, 12999.00, 10.00, 12989.00, 1, 'BoletoParcelado', 12, 'agent_clientes', '2026-03-27 21:36:35.273941-03', 1);
INSERT INTO public."Pedidos" VALUES (33, 14, 46, 249.00, 0.00, 249.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:35.779782-03', 1);
INSERT INTO public."Pedidos" VALUES (34, 15, 54, 449.00, 5.00, 444.00, 1, 'BoletoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:36.288734-03', 1);
INSERT INTO public."Pedidos" VALUES (35, 16, 70, 279.00, 0.00, 279.00, 1, 'PixUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:36.82913-03', 1);
INSERT INTO public."Pedidos" VALUES (36, 17, 113, 1499.00, 7.00, 1492.00, 1, 'CreditoParcelado', 3, 'agent_clientes', '2026-03-27 21:36:37.382479-03', 1);
INSERT INTO public."Pedidos" VALUES (37, 18, 95, 2499.00, 5.00, 2494.00, 1, 'BoletoParcelado', 6, 'agent_clientes', '2026-03-27 21:36:37.942945-03', 1);
INSERT INTO public."Pedidos" VALUES (38, 19, 79, 399.00, 0.00, 399.00, 1, 'CreditoUmaVez', 1, 'agent_clientes', '2026-03-27 21:36:38.495455-03', 1);


--
-- Data for Name: Produtos; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Produtos" VALUES (1, 'iPhone 15 Pro Max 256GB', 'Smartphone Apple com chip A17 Pro, camera 48MP, titanio, 256GB', 9499.00, 25, 'agent_funcionario', '2026-03-27 21:08:49.1894-03', 1);
INSERT INTO public."Produtos" VALUES (2, 'Samsung Galaxy S24 Ultra', 'Smartphone Samsung com S Pen, camera 200MP, 12GB RAM, 512GB', 8799.00, 30, 'agent_funcionario', '2026-03-27 21:08:49.847582-03', 1);
INSERT INTO public."Produtos" VALUES (3, 'Motorola Edge 50 Pro', 'Smartphone Motorola com Snapdragon 7s Gen 2, tela pOLED 144Hz', 3499.00, 45, 'agent_funcionario', '2026-03-27 21:08:49.942043-03', 1);
INSERT INTO public."Produtos" VALUES (4, 'Xiaomi 14 Ultra', 'Smartphone Xiaomi com camera Leica, Snapdragon 8 Gen 3, 512GB', 7299.00, 20, 'agent_funcionario', '2026-03-27 21:08:50.032152-03', 1);
INSERT INTO public."Produtos" VALUES (5, 'Google Pixel 8 Pro', 'Smartphone Google com IA avancada, camera 50MP, 12GB RAM', 6499.00, 18, 'agent_funcionario', '2026-03-27 21:08:50.127482-03', 1);
INSERT INTO public."Produtos" VALUES (6, 'OnePlus 12 256GB', 'Smartphone OnePlus com Hasselblad camera, carregamento 100W', 4299.00, 35, 'agent_funcionario', '2026-03-27 21:08:50.224342-03', 1);
INSERT INTO public."Produtos" VALUES (7, 'iPhone 14 128GB', 'Smartphone Apple com chip A15 Bionic, camera dupla 12MP', 5999.00, 40, 'agent_funcionario', '2026-03-27 21:08:50.323964-03', 1);
INSERT INTO public."Produtos" VALUES (8, 'Samsung Galaxy A55 5G', 'Smartphone Samsung intermediario com tela AMOLED 120Hz', 2299.00, 60, 'agent_funcionario', '2026-03-27 21:08:50.569209-03', 1);
INSERT INTO public."Produtos" VALUES (9, 'Motorola Moto G84 5G', 'Smartphone Motorola com tela pOLED 6.5 polegadas, 256GB', 1299.00, 80, 'agent_funcionario', '2026-03-27 21:08:50.718851-03', 1);
INSERT INTO public."Produtos" VALUES (10, 'Realme GT5 Pro', 'Smartphone Realme com Snapdragon 8 Gen 3, carregamento 240W', 3899.00, 28, 'agent_funcionario', '2026-03-27 21:08:50.821513-03', 1);
INSERT INTO public."Produtos" VALUES (11, 'MacBook Pro M3 14 polegadas', 'Notebook Apple com chip M3 Pro, 18GB RAM, 512GB SSD, tela Liquid Retina XDR', 14999.00, 12, 'agent_funcionario', '2026-03-27 21:09:14.964388-03', 1);
INSERT INTO public."Produtos" VALUES (12, 'Dell XPS 15 9530', 'Notebook Dell com Intel Core i9-13900H, 32GB RAM, 1TB SSD, tela OLED 3.5K', 12999.00, 15, 'agent_funcionario', '2026-03-27 21:09:15.055055-03', 1);
INSERT INTO public."Produtos" VALUES (13, 'Lenovo ThinkPad X1 Carbon Gen 11', 'Notebook Lenovo empresarial com Intel Core i7, 16GB RAM, 512GB SSD, ultraleve', 11499.00, 10, 'agent_funcionario', '2026-03-27 21:09:15.140326-03', 1);
INSERT INTO public."Produtos" VALUES (14, 'Asus ROG Zephyrus G14 2024', 'Notebook gamer Asus com AMD Ryzen 9, RTX 4070, 32GB RAM, 1TB SSD', 9799.00, 18, 'agent_funcionario', '2026-03-27 21:09:15.271126-03', 1);
INSERT INTO public."Produtos" VALUES (15, 'HP Spectre x360 14', 'Notebook 2-em-1 HP com Intel Core i7, 16GB RAM, 1TB SSD, tela OLED touch', 8499.00, 20, 'agent_funcionario', '2026-03-27 21:09:15.364086-03', 1);
INSERT INTO public."Produtos" VALUES (16, 'Microsoft Surface Laptop 5', 'Notebook Microsoft com Intel Core i5, 16GB RAM, 512GB SSD, tela PixelSense', 7299.00, 22, 'agent_funcionario', '2026-03-27 21:09:15.467452-03', 1);
INSERT INTO public."Produtos" VALUES (17, 'Samsung Galaxy Book3 Pro', 'Notebook Samsung com Intel Core i7, 16GB RAM, 512GB SSD, tela AMOLED', 6999.00, 25, 'agent_funcionario', '2026-03-27 21:09:15.561624-03', 1);
INSERT INTO public."Produtos" VALUES (18, 'Acer Nitro 5 AN515', 'Notebook gamer Acer com Intel Core i5-12500H, RTX 4060, 16GB RAM, 512GB SSD', 5299.00, 30, 'agent_funcionario', '2026-03-27 21:09:15.688472-03', 1);
INSERT INTO public."Produtos" VALUES (19, 'Lenovo IdeaPad Gaming 3', 'Notebook Lenovo com AMD Ryzen 5, RTX 3050, 8GB RAM, 512GB SSD', 4499.00, 35, 'agent_funcionario', '2026-03-27 21:09:15.795942-03', 1);
INSERT INTO public."Produtos" VALUES (20, 'Dell Inspiron 15 3520', 'Notebook Dell com Intel Core i5-1235U, 8GB RAM, 256GB SSD, tela Full HD', 3799.00, 40, 'agent_funcionario', '2026-03-27 21:09:15.903744-03', 1);
INSERT INTO public."Produtos" VALUES (21, 'Samsung QLED 65 4K Q80C', 'TV Samsung QLED 65 polegadas 4K com Quantum HDR, 120Hz e Smart TV', 5999.00, 20, 'agent_funcionario', '2026-03-27 21:09:44.622331-03', 1);
INSERT INTO public."Produtos" VALUES (22, 'LG OLED 55 C3 4K', 'TV LG OLED evo 55 polegadas, painel WOLED, 120Hz, Dolby Vision, webOS', 7499.00, 15, 'agent_funcionario', '2026-03-27 21:09:44.769801-03', 1);
INSERT INTO public."Produtos" VALUES (23, 'Sony Bravia XR 75 X95L', 'TV Sony 75 polegadas Mini LED 4K com processador XR, Google TV', 11999.00, 8, 'agent_funcionario', '2026-03-27 21:09:44.852376-03', 1);
INSERT INTO public."Produtos" VALUES (24, 'TCL QLED 58 4K C645', 'TV TCL QLED 58 polegadas 4K com Google TV, 144Hz e Dolby Atmos', 2799.00, 35, 'agent_funcionario', '2026-03-27 21:09:44.940206-03', 1);
INSERT INTO public."Produtos" VALUES (25, 'Philips Ambilight 50 4K', 'TV Philips 50 polegadas com tecnologia Ambilight 3 lados, 4K HDR', 3299.00, 25, 'agent_funcionario', '2026-03-27 21:09:45.029951-03', 1);
INSERT INTO public."Produtos" VALUES (26, 'Samsung Neo QLED 75 8K QN900C', 'TV Samsung Neo QLED 75 polegadas 8K com Neural Quantum Processor', 9999.00, 10, 'agent_funcionario', '2026-03-27 21:09:45.115952-03', 1);
INSERT INTO public."Produtos" VALUES (27, 'LG NanoCell 43 4K', 'TV LG NanoCell 43 polegadas 4K com WebOS, ThinQ AI e HDR10 Pro', 2199.00, 40, 'agent_funcionario', '2026-03-27 21:09:45.24663-03', 1);
INSERT INTO public."Produtos" VALUES (28, 'Panasonic MX800 65 4K', 'TV Panasonic 65 polegadas LED 4K com Google TV, HDR10 e HLG', 4999.00, 18, 'agent_funcionario', '2026-03-27 21:09:45.341497-03', 1);
INSERT INTO public."Produtos" VALUES (29, 'LG UltraWide 34 QHD', 'Monitor LG UltraWide 34 polegadas QHD 2560x1080 IPS, 100Hz, FreeSync', 3299.00, 22, 'agent_funcionario', '2026-03-27 21:09:45.44831-03', 1);
INSERT INTO public."Produtos" VALUES (30, 'Samsung Odyssey G9 49 DQHD', 'Monitor gamer Samsung 49 polegadas curvo DQHD 240Hz, G-Sync e FreeSync', 7999.00, 12, 'agent_funcionario', '2026-03-27 21:09:45.543635-03', 1);
INSERT INTO public."Produtos" VALUES (31, 'Dell UltraSharp 27 4K U2723D', 'Monitor profissional Dell 27 polegadas 4K IPS Black, USB-C 90W', 4499.00, 18, 'agent_funcionario', '2026-03-27 21:09:45.641331-03', 1);
INSERT INTO public."Produtos" VALUES (32, 'ASUS ROG Swift 27 165Hz PG279QM', 'Monitor gamer ASUS 27 polegadas QHD 240Hz IPS, G-Sync Ultimate', 2999.00, 25, 'agent_funcionario', '2026-03-27 21:09:45.730267-03', 1);
INSERT INTO public."Produtos" VALUES (33, 'BenQ PD3220U 32 4K', 'Monitor profissional BenQ 32 polegadas 4K USB-C para designers', 3799.00, 15, 'agent_funcionario', '2026-03-27 21:09:45.862598-03', 1);
INSERT INTO public."Produtos" VALUES (34, 'Acer Predator XB273U 27', 'Monitor gamer Acer 27 polegadas QHD 170Hz IPS, G-Sync Compatible', 2499.00, 28, 'agent_funcionario', '2026-03-27 21:09:46.050862-03', 1);
INSERT INTO public."Produtos" VALUES (35, 'Philips 279C9 27 4K', 'Monitor Philips 27 polegadas 4K IPS com USB-C, webcam integrada', 1899.00, 30, 'agent_funcionario', '2026-03-27 21:09:46.261759-03', 1);
INSERT INTO public."Produtos" VALUES (36, 'LG 27GP850 27 QHD 165Hz', 'Monitor gamer LG 27 polegadas QHD 165Hz Nano IPS, G-Sync Compatible', 2199.00, 32, 'agent_funcionario', '2026-03-27 21:09:46.406397-03', 1);
INSERT INTO public."Produtos" VALUES (37, 'Keychron K2 Mecanico Red', 'Teclado mecanico Keychron K2 75% com switches Red, retroiluminacao RGB', 799.00, 50, 'agent_funcionario', '2026-03-27 21:10:15.730572-03', 1);
INSERT INTO public."Produtos" VALUES (38, 'Logitech MX Keys Advanced', 'Teclado sem fio Logitech para produtividade, retroiluminacao adaptativa', 699.00, 45, 'agent_funcionario', '2026-03-27 21:10:15.826993-03', 1);
INSERT INTO public."Produtos" VALUES (39, 'Corsair K70 RGB Pro', 'Teclado mecanico Corsair K70 com Cherry MX Red, RGB por tecla, USB', 899.00, 38, 'agent_funcionario', '2026-03-27 21:10:15.917558-03', 1);
INSERT INTO public."Produtos" VALUES (40, 'Razer BlackWidow V3 TKL', 'Teclado mecanico Razer TKL com switches Razer Green, RGB Chroma', 749.00, 42, 'agent_funcionario', '2026-03-27 21:10:16.044942-03', 1);
INSERT INTO public."Produtos" VALUES (41, 'HyperX Alloy FPS Pro', 'Teclado mecanico HyperX TKL compacto com Cherry MX Red, iluminacao vermelha', 549.00, 55, 'agent_funcionario', '2026-03-27 21:10:16.134793-03', 1);
INSERT INTO public."Produtos" VALUES (42, 'Ducky One 3 Mini 60', 'Teclado mecanico Ducky 60% com switches Cherry MX, hotswap, PBT duplo', 1099.00, 20, 'agent_funcionario', '2026-03-27 21:10:16.2285-03', 1);
INSERT INTO public."Produtos" VALUES (43, 'Anne Pro 2 Bluetooth', 'Teclado mecanico 60% Anne Pro 2 com Bluetooth e switches Gateron Red', 649.00, 30, 'agent_funcionario', '2026-03-27 21:10:16.321128-03', 1);
INSERT INTO public."Produtos" VALUES (44, 'SteelSeries Apex Pro TKL', 'Teclado mecanico SteelSeries com switches OmniPoint ajustaveis, OLED display', 1299.00, 22, 'agent_funcionario', '2026-03-27 21:10:16.45068-03', 1);
INSERT INTO public."Produtos" VALUES (45, 'Logitech MX Master 3S', 'Mouse sem fio premium Logitech com scroll MagSpeed, sensor 8000 DPI', 549.00, 60, 'agent_funcionario', '2026-03-27 21:10:16.544466-03', 1);
INSERT INTO public."Produtos" VALUES (46, 'Razer DeathAdder V3 Pro', 'Mouse gamer sem fio Razer 63g ultralight com sensor Focus Pro 30K DPI', 699.00, 40, 'agent_funcionario', '2026-03-27 21:10:16.63762-03', 1);
INSERT INTO public."Produtos" VALUES (47, 'SteelSeries Rival 650 Wireless', 'Mouse gamer sem fio SteelSeries com dual sensor e carregamento rapido', 479.00, 35, 'agent_funcionario', '2026-03-27 21:10:16.725457-03', 1);
INSERT INTO public."Produtos" VALUES (48, 'Corsair M65 RGB Elite', 'Mouse gamer Corsair com sniper button, sensor PixArt 18000 DPI', 349.00, 55, 'agent_funcionario', '2026-03-27 21:10:16.832907-03', 1);
INSERT INTO public."Produtos" VALUES (49, 'HyperX Pulsefire Haste 2', 'Mouse gamer HyperX ultralight 53g com sensor TrueMove 26K DPI', 299.00, 70, 'agent_funcionario', '2026-03-27 21:10:16.916796-03', 1);
INSERT INTO public."Produtos" VALUES (50, 'Logitech G Pro X Superlight 2', 'Mouse gamer sem fio Logitech 60g com sensor HERO 2 32K DPI', 799.00, 30, 'agent_funcionario', '2026-03-27 21:10:17.061412-03', 1);
INSERT INTO public."Produtos" VALUES (51, 'Glorious Model O Wireless', 'Mouse gamer sem fio Glorious 69g com sensor Pixart 3370 19000 DPI', 329.00, 45, 'agent_funcionario', '2026-03-27 21:10:17.152709-03', 1);
INSERT INTO public."Produtos" VALUES (52, 'Zowie EC2-C', 'Mouse gamer Zowie ergonomico sem drivers, sensor 3360 3200 DPI', 459.00, 38, 'agent_funcionario', '2026-03-27 21:10:17.245351-03', 1);
INSERT INTO public."Produtos" VALUES (53, 'Sony WH-1000XM5', 'Headset sem fio Sony com cancelamento de ruido de classe mundial, 30h bateria', 1899.00, 35, 'agent_funcionario', '2026-03-27 21:25:22.354507-03', 1);
INSERT INTO public."Produtos" VALUES (54, 'Bose QuietComfort 45', 'Headset sem fio Bose com ANC, modo Aware, 24h bateria e conforto premium', 2199.00, 28, 'agent_funcionario', '2026-03-27 21:25:22.541101-03', 1);
INSERT INTO public."Produtos" VALUES (55, 'Jabra Evolve2 85', 'Headset empresarial Jabra com ANC avancado, microfone 8 capsulas, certificado UC', 3499.00, 15, 'agent_funcionario', '2026-03-27 21:25:22.70066-03', 1);
INSERT INTO public."Produtos" VALUES (56, 'HyperX Cloud Alpha Wireless', 'Headset gamer sem fio HyperX com 300h bateria, drivers duplos 50mm', 899.00, 50, 'agent_funcionario', '2026-03-27 21:25:22.804022-03', 1);
INSERT INTO public."Produtos" VALUES (57, 'Razer BlackShark V2 Pro', 'Headset gamer sem fio Razer com THX Spatial Audio, microfone destacavel', 799.00, 45, 'agent_funcionario', '2026-03-27 21:25:22.902956-03', 1);
INSERT INTO public."Produtos" VALUES (58, 'SteelSeries Arctis Nova Pro', 'Headset premium SteelSeries com ANC, hi-res audio e bateria dupla', 1499.00, 22, 'agent_funcionario', '2026-03-27 21:25:23.014826-03', 1);
INSERT INTO public."Produtos" VALUES (59, 'Logitech G535 Lightspeed', 'Headset gamer sem fio Logitech 236g ultra-leve, 33h bateria', 699.00, 40, 'agent_funcionario', '2026-03-27 21:25:23.139292-03', 1);
INSERT INTO public."Produtos" VALUES (60, 'JBL Quantum 810 Wireless', 'Headset gamer sem fio JBL com ANC, JBL QuantumSURROUND, 49h bateria', 899.00, 38, 'agent_funcionario', '2026-03-27 21:25:23.251121-03', 1);
INSERT INTO public."Produtos" VALUES (61, 'iPad Pro M2 12.9 Wi-Fi 256GB', 'Tablet Apple com chip M2, tela Liquid Retina XDR, Apple Pencil 2, Face ID', 12499.00, 10, 'agent_funcionario', '2026-03-27 21:25:23.353009-03', 1);
INSERT INTO public."Produtos" VALUES (62, 'Samsung Galaxy Tab S9 Plus', 'Tablet Samsung com Snapdragon 8 Gen 2, tela AMOLED 12.4, S Pen incluida', 6999.00, 18, 'agent_funcionario', '2026-03-27 21:25:23.449611-03', 1);
INSERT INTO public."Produtos" VALUES (63, 'iPad Air 5 Wi-Fi 64GB', 'Tablet Apple com chip M1, tela Liquid Retina 10.9, USB-C, Touch ID', 5499.00, 22, 'agent_funcionario', '2026-03-27 21:25:23.549511-03', 1);
INSERT INTO public."Produtos" VALUES (64, 'Microsoft Surface Pro 9', 'Tablet 2-em-1 Microsoft com Intel Core i5, 8GB RAM, 128GB SSD, Windows 11', 9999.00, 12, 'agent_funcionario', '2026-03-27 21:25:23.65491-03', 1);
INSERT INTO public."Produtos" VALUES (65, 'Lenovo Tab P12 Pro', 'Tablet Lenovo com Snapdragon 870, tela AMOLED 12.6 2K, 8GB RAM', 3799.00, 20, 'agent_funcionario', '2026-03-27 21:25:23.769681-03', 1);
INSERT INTO public."Produtos" VALUES (66, 'Samsung Galaxy Tab A9 Plus', 'Tablet Samsung acessivel com tela 11 polegadas, Snapdragon 695, 4GB RAM', 1599.00, 45, 'agent_funcionario', '2026-03-27 21:25:23.888402-03', 1);
INSERT INTO public."Produtos" VALUES (67, 'iPad Mini 6 Wi-Fi 64GB', 'Tablet Apple compacto com chip A15 Bionic, tela Liquid Retina 8.3', 4299.00, 25, 'agent_funcionario', '2026-03-27 21:25:24.024466-03', 1);
INSERT INTO public."Produtos" VALUES (68, 'Xiaomi Pad 6 Pro 128GB', 'Tablet Xiaomi com Snapdragon 8 Gen 1, tela 144Hz 2.8K, 8GB RAM', 2899.00, 30, 'agent_funcionario', '2026-03-27 21:25:24.188821-03', 1);
INSERT INTO public."Produtos" VALUES (69, 'Samsung 990 Pro 2TB NVMe', 'SSD Samsung NVMe M.2 2TB PCIe 4.0, leitura 7450 MB/s, escrita 6900 MB/s', 1299.00, 40, 'agent_funcionario', '2026-03-27 21:25:49.703664-03', 1);
INSERT INTO public."Produtos" VALUES (70, 'WD Black SN850X 1TB NVMe', 'SSD WD Black NVMe M.2 1TB PCIe 4.0, leitura 7300 MB/s para gaming', 899.00, 55, 'agent_funcionario', '2026-03-27 21:25:49.795837-03', 1);
INSERT INTO public."Produtos" VALUES (71, 'Seagate FireCuda 530 2TB', 'SSD Seagate NVMe M.2 2TB PCIe 4.0, leitura 7300 MB/s, com dissipador', 1099.00, 35, 'agent_funcionario', '2026-03-27 21:25:49.884653-03', 1);
INSERT INTO public."Produtos" VALUES (72, 'Kingston KC3000 1TB NVMe', 'SSD Kingston NVMe M.2 1TB PCIe 4.0, leitura 7000 MB/s, escrita 6000 MB/s', 699.00, 60, 'agent_funcionario', '2026-03-27 21:25:49.971382-03', 1);
INSERT INTO public."Produtos" VALUES (73, 'Crucial P5 Plus 500GB NVMe', 'SSD Crucial NVMe M.2 500GB PCIe 4.0, leitura 6600 MB/s para notebooks', 399.00, 80, 'agent_funcionario', '2026-03-27 21:25:50.095381-03', 1);
INSERT INTO public."Produtos" VALUES (74, 'Samsung 870 EVO 1TB SATA', 'SSD Samsung SATA 2.5 1TB, leitura 560 MB/s, escrita 530 MB/s, MLC V-NAND', 599.00, 50, 'agent_funcionario', '2026-03-27 21:25:50.201006-03', 1);
INSERT INTO public."Produtos" VALUES (75, 'WD Blue 2TB SATA SSD', 'SSD WD Blue SATA 2.5 2TB, leitura 560 MB/s, ideal para upgrade de notebook', 449.00, 45, 'agent_funcionario', '2026-03-27 21:25:50.299928-03', 1);
INSERT INTO public."Produtos" VALUES (76, 'Lexar NM790 4TB NVMe', 'SSD Lexar NVMe M.2 4TB PCIe 4.0, leitura 7400 MB/s, grande capacidade', 1799.00, 20, 'agent_funcionario', '2026-03-27 21:25:50.391629-03', 1);
INSERT INTO public."Produtos" VALUES (77, 'Corsair Vengeance DDR5 32GB 5200MHz', 'Memoria RAM Corsair DDR5 2x16GB 5200MHz CL40, para plataformas Intel 12a e 13a gen', 799.00, 45, 'agent_funcionario', '2026-03-27 21:25:50.488714-03', 1);
INSERT INTO public."Produtos" VALUES (78, 'G.Skill Trident Z5 64GB DDR5', 'Memoria RAM G.Skill DDR5 2x32GB 6000MHz CL36, alto desempenho, dissipador aluminio', 1599.00, 20, 'agent_funcionario', '2026-03-27 21:25:50.582799-03', 1);
INSERT INTO public."Produtos" VALUES (79, 'Kingston Fury Beast DDR5 16GB', 'Memoria RAM Kingston DDR5 2x8GB 5200MHz, perfil baixo, Intel XMP 3.0', 399.00, 70, 'agent_funcionario', '2026-03-27 21:25:50.668057-03', 1);
INSERT INTO public."Produtos" VALUES (80, 'Crucial Pro DDR5 32GB 5600MHz', 'Memoria RAM Crucial DDR5 2x16GB 5600MHz, compativel AMD e Intel, sem dissipador', 699.00, 50, 'agent_funcionario', '2026-03-27 21:25:50.755067-03', 1);
INSERT INTO public."Produtos" VALUES (81, 'G.Skill Ripjaws V DDR4 16GB', 'Memoria RAM G.Skill DDR4 2x8GB 3200MHz CL16, ideal para gaming e trabalho', 299.00, 90, 'agent_funcionario', '2026-03-27 21:25:50.839527-03', 1);
INSERT INTO public."Produtos" VALUES (82, 'Corsair Vengeance LPX DDR4 32GB', 'Memoria RAM Corsair DDR4 2x16GB 3200MHz, perfil baixo, compativel AMD EXPO', 749.00, 40, 'agent_funcionario', '2026-03-27 21:25:50.92414-03', 1);
INSERT INTO public."Produtos" VALUES (83, 'HyperX Fury DDR4 8GB 3200MHz', 'Memoria RAM HyperX DDR4 8GB 3200MHz, plug and play, dissipador preto', 199.00, 100, 'agent_funcionario', '2026-03-27 21:25:51.014066-03', 1);
INSERT INTO public."Produtos" VALUES (84, 'Patriot Viper Steel DDR4 32GB', 'Memoria RAM Patriot DDR4 2x16GB 3600MHz CL18, dissipador metalico cinza', 549.00, 35, 'agent_funcionario', '2026-03-27 21:25:51.119451-03', 1);
INSERT INTO public."Produtos" VALUES (85, 'NVIDIA GeForce RTX 4090 24GB', 'Placa de video NVIDIA RTX 4090 24GB GDDR6X, 16384 CUDA cores, topo de linha', 14999.00, 8, 'agent_funcionario', '2026-03-27 21:26:59.771176-03', 1);
INSERT INTO public."Produtos" VALUES (86, 'AMD Radeon RX 7900 XTX 24GB', 'Placa de video AMD RX 7900 XTX 24GB GDDR6, RDNA3, 6144 stream processors', 9999.00, 12, 'agent_funcionario', '2026-03-27 21:26:59.905662-03', 1);
INSERT INTO public."Produtos" VALUES (87, 'NVIDIA RTX 4080 Super 16GB', 'Placa de video NVIDIA RTX 4080 Super 16GB GDDR6X, ray tracing avancado', 8499.00, 15, 'agent_funcionario', '2026-03-27 21:26:59.999553-03', 1);
INSERT INTO public."Produtos" VALUES (88, 'AMD Radeon RX 7800 XT 16GB', 'Placa de video AMD RX 7800 XT 16GB GDDR6, otima custo-beneficio 1440p', 3999.00, 25, 'agent_funcionario', '2026-03-27 21:27:00.106528-03', 1);
INSERT INTO public."Produtos" VALUES (89, 'NVIDIA RTX 4070 Ti Super 16GB', 'Placa de video NVIDIA RTX 4070 Ti Super 16GB GDDR6X, 4K gaming', 6499.00, 18, 'agent_funcionario', '2026-03-27 21:27:00.204534-03', 1);
INSERT INTO public."Produtos" VALUES (90, 'AMD Radeon RX 7600 8GB', 'Placa de video AMD RX 7600 8GB GDDR6, excelente para 1080p gaming', 2299.00, 30, 'agent_funcionario', '2026-03-27 21:27:00.29828-03', 1);
INSERT INTO public."Produtos" VALUES (91, 'NVIDIA RTX 4060 8GB', 'Placa de video NVIDIA RTX 4060 8GB GDDR6, eficiente para 1080p e ray tracing', 1899.00, 35, 'agent_funcionario', '2026-03-27 21:27:00.390197-03', 1);
INSERT INTO public."Produtos" VALUES (92, 'AMD Radeon RX 6700 XT 12GB', 'Placa de video AMD RX 6700 XT 12GB GDDR6, otima para 1440p gaming', 2799.00, 22, 'agent_funcionario', '2026-03-27 21:27:00.495196-03', 1);
INSERT INTO public."Produtos" VALUES (93, 'ASUS ROG Rapture GT-AXE16000', 'Roteador ASUS Quad-band Wi-Fi 6E, 16000 Mbps, 8 antenas externas, gaming', 5499.00, 10, 'agent_funcionario', '2026-03-27 21:27:00.593578-03', 1);
INSERT INTO public."Produtos" VALUES (94, 'TP-Link Archer AXE300 Wi-Fi 6E', 'Roteador TP-Link Tri-band Wi-Fi 6E, 10 Gbps porta WAN, OFDMA', 1999.00, 28, 'agent_funcionario', '2026-03-27 21:27:00.684954-03', 1);
INSERT INTO public."Produtos" VALUES (95, 'Netgear Nighthawk RS700S', 'Roteador Netgear Wi-Fi 7 Tri-band, 19.6 Gbps, porta 10G WAN/LAN', 4299.00, 12, 'agent_funcionario', '2026-03-27 21:27:00.800599-03', 1);
INSERT INTO public."Produtos" VALUES (96, 'Ubiquiti UniFi Dream Machine Pro', 'Roteador enterprise Ubiquiti com firewall, switch 8 portas, IPS/IDS', 3799.00, 15, 'agent_funcionario', '2026-03-27 21:27:00.89755-03', 1);
INSERT INTO public."Produtos" VALUES (97, 'TP-Link Deco XE75 Pro Kit 3', 'Sistema mesh Wi-Fi 6E TP-Link, kit 3 unidades, cobertura 700m2', 1499.00, 20, 'agent_funcionario', '2026-03-27 21:27:00.989754-03', 1);
INSERT INTO public."Produtos" VALUES (98, 'Asus ZenWiFi Pro ET12 Kit 2', 'Sistema mesh Wi-Fi 6E Asus, kit 2 unidades, Tri-band 11000 Mbps', 2999.00, 18, 'agent_funcionario', '2026-03-27 21:27:01.093796-03', 1);
INSERT INTO public."Produtos" VALUES (99, 'D-Link EAGLE PRO AI AX3200', 'Roteador D-Link Wi-Fi 6 AX3200 com IA para otimizacao de banda', 899.00, 35, 'agent_funcionario', '2026-03-27 21:27:01.200057-03', 1);
INSERT INTO public."Produtos" VALUES (100, 'Linksys Velop AXE8400 Mesh', 'Sistema mesh Wi-Fi 6E Linksys Tri-band, cobertura ate 260m2 por no', 2199.00, 22, 'agent_funcionario', '2026-03-27 21:27:01.304555-03', 1);
INSERT INTO public."Produtos" VALUES (101, 'HP LaserJet Pro M404dn', 'Impressora laser monocromática, até 38 ppm, duplex automático, USB e Ethernet', 1299.00, 15, 'agent_funcionario', '2026-03-27 21:30:35.151561-03', 1);
INSERT INTO public."Produtos" VALUES (102, 'Canon PIXMA G3110 Mega Tank', 'Impressora jato de tinta colorida com reservatório, WiFi, impressão sem fio', 899.00, 20, 'agent_funcionario', '2026-03-27 21:30:35.812651-03', 1);
INSERT INTO public."Produtos" VALUES (103, 'Epson EcoTank L3250', 'Impressora multifuncional colorida, tanque de tinta, WiFi, USB, 33 ppm preto', 799.00, 25, 'agent_funcionario', '2026-03-27 21:30:36.398-03', 1);
INSERT INTO public."Produtos" VALUES (104, 'Brother DCP-L5502DN', 'Impressora multifuncional laser monocromática, duplex, Ethernet, 40 ppm', 1799.00, 12, 'agent_funcionario', '2026-03-27 21:30:36.999457-03', 1);
INSERT INTO public."Produtos" VALUES (105, 'HP OfficeJet Pro 9015e', 'Impressora jato de tinta colorida, duplex automático, WiFi 6, Ethernet', 1099.00, 18, 'agent_funcionario', '2026-03-27 21:30:37.507367-03', 1);
INSERT INTO public."Produtos" VALUES (106, 'Epson L8050 Photo', 'Impressora fotográfica colorida 6 cores, WiFi, impressão em CD e DVD', 2199.00, 8, 'agent_funcionario', '2026-03-27 21:30:38.066941-03', 1);
INSERT INTO public."Produtos" VALUES (107, 'Samsung ProXpress M4080FX', 'Impressora laser multifuncional monocromática, 40 ppm, fax, rede', 2499.00, 10, 'agent_funcionario', '2026-03-27 21:30:38.618998-03', 1);
INSERT INTO public."Produtos" VALUES (108, 'Canon imageCLASS MF445dw', 'Impressora laser multifuncional, duplex, WiFi, Ethernet, 40 ppm monocromática', 1599.00, 14, 'agent_funcionario', '2026-03-27 21:30:39.198006-03', 1);
INSERT INTO public."Produtos" VALUES (109, 'Xerox WorkCentre 3335', 'Impressora multifuncional laser, 35 ppm, digitalização em rede, USB', 1899.00, 9, 'agent_funcionario', '2026-03-27 21:30:39.853412-03', 1);
INSERT INTO public."Produtos" VALUES (110, 'HP Color LaserJet Pro M454dw', 'Impressora laser colorida, 28 ppm, WiFi, duplex automático, alta qualidade', 2799.00, 7, 'agent_funcionario', '2026-03-27 21:30:40.419353-03', 1);
INSERT INTO public."Produtos" VALUES (111, 'Logitech C920s HD Pro', 'Webcam Full HD 1080p, autofoco, microfone estéreo, USB, ideal para videoconferência', 399.00, 40, 'agent_funcionario', '2026-03-27 21:31:00.215072-03', 1);
INSERT INTO public."Produtos" VALUES (112, 'Logitech StreamCam Plus', 'Webcam USB-C 1080p/60fps, IA detecção facial, rotação vertical, streaming', 699.00, 30, 'agent_funcionario', '2026-03-27 21:31:00.578563-03', 1);
INSERT INTO public."Produtos" VALUES (113, 'Razer Kiyo Pro Ultra', 'Webcam 4K UHD, sensor Sony STARVIS, HDR, autofoco adaptativo, USB-C', 1499.00, 15, 'agent_funcionario', '2026-03-27 21:31:01.224-03', 1);
INSERT INTO public."Produtos" VALUES (114, 'Microsoft LifeCam Studio', 'Webcam HD 1080p, microfone amplo espectro, USB 2.0, compatível Windows', 349.00, 35, 'agent_funcionario', '2026-03-27 21:31:01.664798-03', 1);
INSERT INTO public."Produtos" VALUES (115, 'Elgato Facecam MK.2', 'Webcam 1080p/60fps, sensor Sony, vidro óptico, USB-C, sem compressão', 899.00, 20, 'agent_funcionario', '2026-03-27 21:31:02.066419-03', 1);
INSERT INTO public."Produtos" VALUES (116, 'AVerMedia Live Streamer CAM 513', 'Webcam 4K UHD, HDR, microfone integrado, USB-C, ideal para streamers', 1199.00, 12, 'agent_funcionario', '2026-03-27 21:31:02.475442-03', 1);
INSERT INTO public."Produtos" VALUES (117, 'Logitech Brio 505', 'Webcam 1080p, redução de ruído com IA, Show Mode, USB-C, para home office', 549.00, 28, 'agent_funcionario', '2026-03-27 21:31:02.850271-03', 1);
INSERT INTO public."Produtos" VALUES (118, 'HyperX Vision S', 'Webcam 4K UHD/30fps, HDR, autofoco, microfone cardioid embutido, USB-A', 999.00, 18, 'agent_funcionario', '2026-03-27 21:31:03.317389-03', 1);
INSERT INTO public."Produtos" VALUES (119, 'Anker PowerConf C300', 'Webcam 1080p, AI-powered autofoco, correção de luz, USB-A, compacta', 299.00, 45, 'agent_funcionario', '2026-03-27 21:31:03.725702-03', 1);
INSERT INTO public."Produtos" VALUES (120, 'Poly Studio P5', 'Webcam profissional 1080p, microfone direcional, USB-A, certificada Zoom', 449.00, 22, 'agent_funcionario', '2026-03-27 21:31:04.186105-03', 1);


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20260327233346_InitialCreate', '10.0.5');


--
-- Name: Clientes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Clientes_Id_seq"', 30, true);


--
-- Name: Enderecos_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Enderecos_Id_seq"', 30, true);


--
-- Name: Logs_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Logs_Id_seq"', 1, true);


--
-- Name: Pedidos_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Pedidos_Id_seq"', 38, true);


--
-- Name: Produtos_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Produtos_Id_seq"', 120, true);


--
-- PostgreSQL database dump complete
--

