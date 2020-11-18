provider "aws" {
  region        = var.region
  access_key    = "?"
  secret_key    = "?"
}

terraform {
  backend "s3" {
    bucket  = "tfstate-dev"
    key     = "dev.tfstate"
    region  = "eu-central-1"

    access_key = "?"
    secret_key = "?"
  }
}