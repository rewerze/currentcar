@echo off

start cmd /k "cd /d server && npm install && npm run dev"
start cmd /k "cd /d client && npm install && npm run dev"

exit