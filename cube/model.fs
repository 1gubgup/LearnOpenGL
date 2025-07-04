#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;
in vec2 TexCoords;

uniform sampler2D texture_diffuse1;

uniform vec3 cameraPos;
uniform samplerCube skybox;

void main()
{    
    vec3 I = normalize(Position - cameraPos);
    vec3 R = reflect(I, normalize(Normal));

    vec3 reflectionColor = texture(skybox, R).rgb;
    vec3 baseColor = texture(texture_diffuse1, TexCoords).rgb;

    FragColor = vec4(baseColor * reflectionColor, 1.0);
    
}