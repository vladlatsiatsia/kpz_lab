<?php

class Response {
    private $statusCode = 200;
    private $headers = [];

    public function __construct() {
        if (ob_get_level() == 0) {
            ob_start();
        }
    }

    /**
     */
    public function setStatus($code) {
        $this->statusCode = $code;
        http_response_code($code);
        return $this;
    }

    /**
     */
    public function addHeader($header) {
        $this->headers[] = $header;
        return $this;
    }

    /**
     */
    public function send($content) {
        if (ob_get_length() > 0) {
            ob_clean();
        }


        http_response_code($this->statusCode);

        foreach ($this->headers as $header) {
            header($header);
        }

        echo $content;

        ob_end_flush();
    }
}


$response = new Response();

$response->setStatus(200);
$response->addHeader("Content-Type: text/html; charset=UTF-8");
$response->addHeader("X-Powered-By: MyCustomClass");

$response->send("<h1>Вітаємо!</h1><p>Це відповідь, сформована за допомогою об'єкта класу Response.</p>");
