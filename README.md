# VueDotNetWithDocker
一个简单的CRUD程序，评估 Docker 在开发过程中的优势。

# VUE
1、构建前端镜像(docker-frontend)  
docker image build --no-cache ./ -t docker-frontend

2、创建 docker 容器，将 docker 端口 80 映射到 本机 8000，镜像名称 docker-frontend  
docker container create -p 8000:80 docker-frontend

3、查找容器 id  
docker ps -a

4、启动容器  
docker start 5075095b8cf9  

此时，便可以采用 http://localhost:8000/ 访问 vue 站点了。

