<template>
  <div>AuthComponent</div>
</template>
<script>
import { onMounted } from "vue";

export default {
  name: "AuthComponent",
  setup() {
    function oauthSignIn() {
      var oauth2Endpoint = "https://accounts.google.com/o/oauth2/v2/auth";

      var form = document.createElement("form");
      form.setAttribute("method", "GET");
      form.setAttribute("action", oauth2Endpoint);

      var params = {
        client_id:
          "xyz",
        redirect_uri: "http://localhost:5079/ext/auth",
        response_type: "token",
        scope: "openid",
        state: "pass-through value",
      };

      for (var p in params) {
        var input = document.createElement("input");
        input.setAttribute("type", "hidden");
        input.setAttribute("name", p);
        input.setAttribute("value", params[p]);
        form.appendChild(input);
      }

      document.body.appendChild(form);
      form.submit();
    }

    onMounted(() => {
      oauthSignIn();
    });

    return {};
  },
};
</script>
<style></style>
