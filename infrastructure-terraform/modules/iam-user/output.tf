output "arn" {
  value = aws_iam_user.this.arn
}

output "unique_id" {
  value = aws_iam_user.this.unique_id
}

output "access_key_id" {
  value = aws_iam_access_key.this.id
}

output "access_secret_key" {
  value = aws_iam_access_key.this.secret
}