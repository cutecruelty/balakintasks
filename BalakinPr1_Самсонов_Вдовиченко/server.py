import http.server, socketserver, functools


class H(http.server.SimpleHTTPRequestHandler):
    def end_headers(self):
        self.send_header("Cache-Control", "no-store, no-cache, must-revalidate")
        self.send_header("Pragma", "no-cache")
        self.send_header("Expires", "0")
        super().end_headers()

    def log_message(self, *a):
        pass


Handler = functools.partial(H, directory="/tmp/opencode/site")
with socketserver.ThreadingTCPServer(("127.0.0.1", 8123), Handler) as httpd:
    httpd.serve_forever()
