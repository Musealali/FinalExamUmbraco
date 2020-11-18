module "vpc_network" {
    source = "./modules/vpc"
    env_prefix = var.env_prefix
}