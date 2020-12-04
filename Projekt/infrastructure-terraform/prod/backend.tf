provider "aws" {
  region    = "eu-central-1"
  profile   = "prod"
}

terraform {
  backend "s3" {
    region  = "eu-central-1"
    profile = "prod"

    bucket  = "dmr-umbraco-terraform-state-bucket"
    key     = "prod.tfstate"
  }
}