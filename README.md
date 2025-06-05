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

# WebAPI
采用 visual studio 2022 创建一个 WebAPI 项目，选择启用容器支持。  
容器生成类型选择 Dockerfile 即可。  
运行时通过 Container(Dockerfile)启动，与本机调整没有什么区别。  
唯一麻烦的就是要去 docker 上看看容器的端口映射，通过映射的本机端口访问 webapi。  

vs 自带的示例 http://localhost:54418/weatherforecast/

# Docker compose
参考：  
https://learn.microsoft.com/zh-cn/visualstudio/containers/tutorial-multicontainer?view=vs-2022  
