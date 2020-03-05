--This file contains all the create script of beehive i.e. system files which is common in all the projects.
--Role setup
CREATE TABLE public.beehive_role
(
    id SERIAL PRIMARY KEY,
	banner character varying(20) COLLATE pg_catalog."default" NOT NULL,
	description character varying(200) COLLATE pg_catalog."default",
	is_super_admin boolean NOT NULL,
	is_active boolean NOT NULL	   
)
--Menu Setup
CREATE TABLE public.beehive_menu
(
    id SERIAL PRIMARY KEY,
    banner character varying(20) COLLATE pg_catalog."default" NOT NULL,
    display_banner character varying(20) COLLATE pg_catalog."default" NOT NULL,
    icon character varying(20) COLLATE pg_catalog."default" NOT NULL,
    order_number integer NOT NULL,
    access_to_all boolean NOT NULL,
    is_dashboard_menu boolean NOT NULL,
    is_active boolean NOT NULL,
    parent_id bigint,
    description character varying(200) COLLATE pg_catalog."default",
    routerlink character varying(50) COLLATE pg_catalog."default" NOT NULL DEFAULT ''::character varying
)
--Role menu setup
CREATE TABLE public.beehive_role_menu
(
    id SERIAL PRIMARY KEY,
    role_id bigint NOT NULL REFERENCES beehive_role(id) ,
    menu_id bigint NOT NUll REFERENCES beehive_menu(id),
    hatch  boolean NOT NULL,
    know boolean NOT NULL,
    amend boolean NOT NULL,
    strike_out boolean NOT NULL
)